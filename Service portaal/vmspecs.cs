using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_portaal
{
    class vmspecs
    {
        int aanvraagid;
        DateTime datum;
        String naam;
        string vmnaam;
        string os;
        int cpu;
        int ram;
        string netwerk;
        string folder;
        string datacenter;
        string datastore;
        string reden;

        public vmspecs(int aanvraagid, DateTime datum, string naam, string vmnaam, string os, int cpu, int ram, string netwerk, string folder, string datacenter, string datastore, string reden)
        {

            this.aanvraagid = aanvraagid;
            this.datum = datum;
            this.naam = naam;
            this.vmnaam = vmnaam;
            this.os = os;
            this.cpu = cpu;
            this.ram = ram;
            this.netwerk = netwerk;
            this.folder = folder;
            this.datacenter = datacenter;
            this.datastore = datastore;
            this.reden = reden;

        }
        public int Aanvraagid { get => aanvraagid; set => aanvraagid = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public string Naam { get => naam; set => naam = value; }
        public string Vmnaam { get => vmnaam; set => vmnaam = value; }
        public string Os { get => os; set => os = value; }
        public int Cpu { get => cpu; set => cpu = value; }
        public int Ram { get => ram; set => ram = value; }
        public string Netwerk { get => netwerk; set => netwerk = value; }
        public string Folder { get => folder; set => folder = value; }
        public string Datacenter { get => datacenter; set => datacenter = value; }
        public string Datastore { get => datastore; set => datastore = value; }
        public string Reden { get => reden; set => reden = value; }


        public override string ToString()
        {
            return aanvraagid + datum.ToString() + naam + vmnaam + os + cpu + ram + netwerk + folder + datacenter + datastore + reden;
        }

    }
}
