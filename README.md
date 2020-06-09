Service Portaal Vcenter
Een service portaal voor het aanvragen van VM's binnen Vcenter. En het openen van Tickets m.b.t. Vcenter. 

Met dit service portaal kan men VM's aanvragen. Deze software is een Proof of Concept voor een service portaal in HTML. 

In deze readme zal ik bespreken wat nodig is om gebruik te maken van deze reposority. 

* Dependencies
* Onderdelen 



Dependencies:

Binnen dit project worden twee programmeer talen gecombineerd namelijk, C# & Python. Iedere programmeer taal heeft zijn eigen dependencies. 

Python: 

Binnen Python zijn de scripts geschreven die communiceren met Vcenter. om dit te realiseren moet men als eerste de Vmware automation sdk installeren.
Deze kan men hieronder vinden:

https://github.com/vmware/vsphere-automation-sdk-python

C#: 

Binnen C# is de G

Onderdelen:

De beide onderdelen hebben ook een eigen opbouw deze bespreek ik in dit hoofdstuk. 

Python: 

Er zijn in totaal 4 scripts binnen python geschreven. Hieronder zal ik ze per stuk bespreken. 

VM Creatie:

Dit script maakt een standaard VM aan met 2 cores en 4 GB RAM. Hiervoor zijn enkele parameters nodig namelijk: 

* Machine naam
* Datacenter
* Locatie 
* Datastore 
* Portgroup
* OS

Deze heeft het python script nodig wanneer deze wordt aangeroepen. Daarnaast heeft het python script ook de gegevens van Vcenter nodig. 
Deze staan als variabele in het script. Deze moet men aanpassen naar de gewenste gegevens. 


CPU configuratie: 

Dit script zorgt voor de juiste configuratie van de cpu voor een VM. Hierbij zijn uiteraard ook enkele parameters bij betrokken.

* Machine naam
* Aantal cores

Wanneer het script wordt aangeroepen gaat het opzoek naar de mee gegeven machine naam binnen Vcenter en veranderd het aantal CPU cores. 
Daarnaast heeft het python script ook de gegevens van Vcenter nodig. 
Deze staan als variabele in het script. Deze moet men aanpassen naar de gewenste gegevens.

RAM Configuratie: 

Dit script zorgt voor de juiste configuratie van het RAM voor een VM. Hierbij zijn uiteraard ook enkele parameters bij betrokken.

* Machine naam
* Aantal GB RAM

Wanneer het script wordt aangeroepen gaat het opzoek naar de mee gegeven machine naam binnen Vcenter en veranderd het RAM. 
Daarnaast heeft het python script ook de gegevens van Vcenter nodig. 
Deze staan als variabele in het script. Deze moet men aanpassen naar de gewenste gegevens.

Ethernet Configuratie:

Dit script zorgt voor de juiste configuratie van de NIC voor een VM. Hierbij zijn uiteraard ook enkele parameters bij betrokken.

* Machine naam
* Portgroup
* Datacenternaam

Wanneer het script wordt aangeroepen gaat het opzoek naar de mee gegeven machine naam binnen Vcenter en veranderd het de portgroup. 
Daarnaast heeft het python script ook de gegevens van Vcenter nodig. 
Deze staan als variabele in het script. Deze moet men aanpassen naar de gewenste gegevens.




