"""
* *******************************************************
* Copyright (c) VMware, Inc. 2016-2018. All Rights Reserved.
* SPDX-License-Identifier: MIT
* *******************************************************
*
* DISCLAIMER. THIS PROGRAM IS PROVIDED TO YOU "AS IS" WITHOUT
* WARRANTIES OR CONDITIONS OF ANY KIND, WHETHER ORAL OR WRITTEN,
* EXPRESS OR IMPLIED. THE AUTHOR SPECIFICALLY DISCLAIMS ANY IMPLIED
* WARRANTIES OR CONDITIONS OF MERCHANTABILITY, SATISFACTORY QUALITY,
* NON-INFRINGEMENT AND FITNESS FOR A PARTICULAR PURPOSE.
"""

__author__ = 'VMware, Inc.'
__vcenter_version__ = '6.5+'

from vmware.vapi.vsphere.client import create_vsphere_client

from com.vmware.vcenter.vm.hardware_client import Ethernet
from com.vmware.vcenter_client import Network

from samples.vsphere.common.sample_util import parse_cli_args_vm
from samples.vsphere.common.sample_util import pp
from samples.vsphere.vcenter.helper import network_helper
from samples.vsphere.vcenter.setup import testbed
import sys
from samples.vsphere.vcenter.helper.vm_helper import get_vm
from samples.vsphere.common.ssl_helper import get_unverified_session

"""
Demonstrates how to configure virtual ethernet adapters of a virtual machine.
Sample Prerequisites:
The sample needs an existing VM.
"""
global vm_name
global netwerk
global datacentername
vm_name = sys.argv[1]
netwerk = sys.argv[2]
datacentername = sys.argv[3]
vm = None

client = None
cleardata = False
nics_to_delete = []
orig_nic_summaries = None

username1 ="administrator@vsphere.local"
password1 = 'Adminadmin/24'
server1 = "192.168.8.36"


def setup(context=None):

    global vm, vm_name, client, cleardata
    if context:
        # Run sample suite via setup script
        client = context.client

    else:
        # Run sample in standalone mode

        session = get_unverified_session()

        # Connect to vSphere client
        client = create_vsphere_client(server=server1,
                                       username=username1,
                                       password=password1,
                                       session=session)


def run():
    global vm
    vm = get_vm(client, vm_name)
    if not vm:
        raise Exception('Sample requires an existing vm with name ({}). '
                        'Please create the vm first.'.format(vm_name))
    print("Using VM '{}' ({}) for Disk Sample".format(vm_name, vm))



    # Get distributed portgroup to use as backing for sample
    distributed_network = network_helper.get_network_backing(
        client,
       netwerk,
        datacentername,
        Network.Type.DISTRIBUTED_PORTGROUP)

    print('\n# Example: List all Ethernet adapters for a VM')
    nic_summaries = client.vcenter.vm.hardware.Ethernet.list(vm=vm)
    print('vm.hardware.Ethernet.list({}) -> {}'.format(vm, nic_summaries))

    # Save current list of Ethernet adapters to verify that we have cleaned
    # up properly
    global orig_nic_summaries
    orig_nic_summaries = nic_summaries

    # Get information for each Ethernet on the VM
    for nic_summary in nic_summaries:
        nic = nic_summary.nic
        nic_info = client.vcenter.vm.hardware.Ethernet.get(vm=vm, nic=nic)
        print('vm.hardware.Ethernet.get({}, {}) -> {}'.
              format(vm, nic, nic_info))

    global nics_to_delete

    print('\n# Example: Update Ethernet Nic with different backing')
    nic_update_spec = Ethernet.UpdateSpec(
        start_connected=True,
        backing=Ethernet.BackingSpec(
            type=Ethernet.BackingType.DISTRIBUTED_PORTGROUP,
            network=distributed_network))
    print('vm.hardware.Ethernet.update({}, {}, {})'.
          format(vm, nic, nic_update_spec))
    client.vcenter.vm.hardware.Ethernet.update(vm, nic, nic_update_spec)
    nic_info = client.vcenter.vm.hardware.Ethernet.get(vm, nic)
    print('vm.hardware.Ethernet.get({}, {}) -> {}'.
          format(vm, nic, pp(nic_info)))

    print('\n# Example: Update Ethernet Nic wake_on_lan_enabled=False')
    print('#                              mac_type=GENERATED,')
    print('#                              start_connected=False,')
    print('#                              allow_guest_control=False')
    nic_update_spec = Ethernet.UpdateSpec(
        wake_on_lan_enabled=False,
        mac_type=Ethernet.MacAddressType.GENERATED,
        start_connected=False,
        allow_guest_control=False)
    print('vm.hardware.Ethernet.update({}, {}, {})'.
          format(vm, nic, nic_update_spec))
    client.vcenter.vm.hardware.Ethernet.update(vm, nic, nic_update_spec)
    nic_info = client.vcenter.vm.hardware.Ethernet.get(vm, nic)
    print('vm.hardware.Ethernet.get({}, {}) -> {}'.
          format(vm, nic, pp(nic_info)))

    # List all Nics for a VM
    nic_summaries = client.vcenter.vm.hardware.Ethernet.list(vm=vm)
    print('vm.hardware.Ethernet.list({}) -> {}'.format(vm, nic_summaries))


def cleanup():
    print('\n# Cleanup: Delete VM Nics that were added')
    for nic in nics_to_delete:
        client.vcenter.vm.hardware.Ethernet.delete(vm, nic)
        print('vm.hardware.Ethernet.delete({}, {})'.format(vm, nic))

    nic_summaries = client.vcenter.vm.hardware.Ethernet.list(vm)
    print('vm.hardware.Ethernet.list({}) -> {}'.format(vm, nic_summaries))
    if set(orig_nic_summaries) != set(nic_summaries):
        print('vm.hardware.Ethernet WARNING: '
              'Final Nic info does not match original')


def main():

    setup()
    run()
    if cleardata:
        cleanup()


if __name__ == '__main__':
    main()