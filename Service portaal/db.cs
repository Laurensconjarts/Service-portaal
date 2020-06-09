using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace Service_portaal
{
    class db
    {
        private string connectionString;
        private SqlConnection conn;
        SqlCommand command;
        public static string query;
       

        public SqlCommand Command
        {
            get
            {
                return command;
            }
            set
            {
                command = value;
            }
        }
        public db()
        {

            connectionString = @"Server=192.168.8.39;Database=vcenter;User Id=vcenter;Password=Adminadmin/24";
            conn = new SqlConnection(connectionString);
            conn.Open();

            command = conn.CreateCommand();

            
        }
        public List<vmspecs> Vmspecificaties(int Aanvraagid)
        {
            List<vmspecs> Vmspecificaties = new List<vmspecs>();
            SqlConnection con = new SqlConnection(@"Server=192.168.8.39;Database=vcenter;User Id=vcenter;Password=Adminadmin/24");
            SqlDataReader reader;
            SqlCommand command;
            con.Open();
           
            if (Aanvraagid == 0)
            {
                query = "select * from Vm_Aanvragen";
              
            }
            else if (Aanvraagid != 0)
            {
                query = "select * from Vm_Aanvragen where aanvraagid = @aanvraag";
                
                
            }
            
            

            command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@aanvraag", Aanvraagid);
            reader = command.ExecuteReader();


          

            
            while (reader.Read())
            {
                int aanvraagid = reader.GetInt32(0);
                DateTime datum = reader.GetDateTime(1);
                String naam = reader.GetString(2);
                string vmnaam = reader.GetString(3);
                string os = reader.GetString(4);
                int cpu = reader.GetInt32(5);
                int ram = reader.GetInt32(6);
                string netwerk = reader.GetString(7);
                string folder = reader.GetString(8);
                string datacenter = reader.GetString(9);
                string datastore = reader.GetString(10);
                string reden = reader.GetString(11);

                if (Aanvraagid == 0)
                {
                    Vmspecificaties.Add(new vmspecs(aanvraagid, datum, naam, vmnaam, os, cpu, ram, netwerk, folder, datacenter, datastore, reden));
                }
                else if (Aanvraagid != 0)
                {

                    VM_beheer.aanvraagid = aanvraagid;
                    VM_beheer.datum = datum;
                    VM_beheer.naam = naam;
                    VM_beheer.vmnaam = vmnaam;
                    VM_beheer.os = os;
                    VM_beheer.cpu = cpu;
                    VM_beheer.ram = ram;
                    VM_beheer.netwerk = netwerk;
                    VM_beheer.folder = folder;
                    VM_beheer.datacenter = datacenter;
                    VM_beheer.datastore = datastore;
                    VM_beheer.reden = reden;

                   
                }
            }
            con.Close();
            return Vmspecificaties;

        }

       




    }
}
