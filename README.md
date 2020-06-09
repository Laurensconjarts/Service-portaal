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

Binnen C# is de GUI ontwikkeld van dit service portaal. Deze GUI communiceert met Python doormiddel van CMD, Active Directory identity manager en met een MSSQL database. Om dit mogelijk te maken moet men verschillende dependencies installeren. 

Python: 

https://www.python.org/downloads/release/python-383/

MSSQL: 

SQL server:

https://www.microsoft.com/nl-nl/sql-server/sql-server-downloads

Database script:

Draai het sql script wat in de map database staat. 


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

Binnen C# zijn er ook verschillende onderdelen deze zal ik per stuk bespreken. 

Login scherm: 

Als eerste onderdeel van de applicatie is er een login scherm. Op dit login scherm moet men inloggen met een active directory account. Om dit werkend te krijgen moet men in de login code de Active Directory server gegevens aanpassen naar de gegevens van de desbetreffende situatie. Wanneer men is ingelogd wordt er door een if statement gekeken of de gebruiker in een bepaalde groep zit met de naam Administrator. Wanneer dit het geval is opent het menu voor de administrator. Je kan het if statement aanpassen naar wens met welke groep welk scherm krijgt te zien. 

Menu: 

Op dit scherm kan men keuze maken tussen verschillende opties. Namelijk een ticket openen of een VM aanvragen. Wanneer men als een administrator inlogt komt er een extra optie bij staan namelijk VM aanvragen beheren. Wanneer men op de knoppen klikt opent het nieuwe scherm. 

VM aanvragen: 

Op dit scherm kan men een VM aanvragen. Hierbij moet men dan verschillende velden invullen zoals CPU & RAM. Maar men moet ook een netwerk kiezen. Hier komen niet alle netwerken te staan. Hier komen alleen de netwerken te staan waar de gebruiker toegang tot heeft. Dit is gerealiseerd. door een Database tabel met twee kolomen namelijk Groep & netwerk. Er wordt dan gekeken in welke groepen de gebruiker zit. Vervolgens wordt gekeken welk netwerk bij welke groep hoort dit gebeurd met queries. Vervolgens worden de netwerken in de GUI weergegeven. Wanneer je op aanvragen drukt wordt de data weggeschreven naar een andere database tabel. 

VM beheer: 

Op dit scherm kan een administrator alle VM aanvragen zien. Wanneer hij op goedkeuren drukt worden de python scripts afgetrapt. Door de methodes echter moet men de locatie naar de scripts aanpassen naar de locatie in de situatie. 
Wanneer de aanvraag is afgehandeld wordt hij weg geschreven naar de tabel aanvraag_archief. Dit is een tabel waar men alle aanvragen in kan zien.




