using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace Service_portaal
{
    /// <summary>
    /// Interaction logic for newvm.xaml
    /// </summary>
    public partial class newvm : Window
    {
        private string username;
        private string password;
        private string vmnaam;
        private string os;
        private string netwerk;
        private string folder;
        private string reden;
        private string[] groepen;
        private int cpu;
        private int ram;
        private List<string> cpulist = new List<string>();
        public List<string> groepu = new List<string>();
        private List<string> ramlist = new List<string>();
        private List<string> niclist = new List<string>();
        private List<string> locatielist = new List<string>();
        private List<string> oslist = new List<string>();
        db datab = new db();

        public newvm()
        {
            InitializeComponent();

        }
        public newvm(string username, string password, string[] groepen)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.groepen = groepen;
            groepenanalyse();
            data();

        }




     

        public void groepenanalyse()
        {
            
            string klas = Array.Find(groepen,
                       element => element.StartsWith("k",
                       StringComparison.Ordinal));
            string proftaak = Array.Find(groepen,
                       element => element.StartsWith("P",
                       StringComparison.Ordinal));
            string administrator = Array.Find(groepen,
                       element => element.StartsWith("Administrator",
                       StringComparison.Ordinal));

            if (klas != null)
            {
                netwerkadapter(klas);
            }

            if (proftaak != null)
            {
                netwerkadapter(proftaak);
            }

            if (administrator != null)
            {
                netwerkadapter(administrator);
            }
            if (klas != null && proftaak != null && administrator != null)
            {
                niclist.Add("VM Network");
            }
        }

        public void netwerkadapter(string groep)
        {
            SqlDataReader reader;
            string query = "Select Portgroup from VM_Netwerk Where Groep=@groep";
            datab.Command.Parameters.AddWithValue("@groep", groep);

            datab.Command.CommandText = query;
            datab.Command.ExecuteNonQuery();
            
            reader = datab.Command.ExecuteReader();
            while (reader.Read())
                {
                    niclist.Add(reader.GetString(0));


                }
            datab.Command.Parameters.Clear();
            reader.Close();
           
           
        }

        public void vars()
        {
           

            if (vmnaamtb.Text != null && oscb.SelectedItem != null && niccb.SelectedItem != null && cpucb.SelectedItem != null && ramcb.SelectedItem != null && vmlocb.SelectedItem != null && aanvraagtb.Text != null)
            {
                vmnaam = vmnaamtb.Text;
                os = oscb.SelectedItem.ToString();
                netwerk = niccb.SelectedItem.ToString();
                cpu = Convert.ToInt32(cpucb.SelectedItem);
                ram = Convert.ToInt32(ramcb.SelectedItem);
                folder = vmlocb.SelectedItem.ToString();
                reden = aanvraagtb.Text;
                dbquerysend();
            
            
            }
            else
            {
                MessageBox.Show("sfeer");
            }
        }
        public void data()

        {
            
            string[] os = { "WINDOWS_9", "Linux", "macos" };
            string[] cpuram = { "1", "2", "3","4","5","6","7","8","9","10" };
            cpulist.AddRange(cpuram);
            ramlist.AddRange(cpuram);
            oslist.AddRange(os);
            locatielist.Add(username);
            oscb.ItemsSource = oslist;
            cpucb.ItemsSource = cpulist;
            ramcb.ItemsSource = ramlist;
            niccb.ItemsSource = niclist;
            vmlocb.ItemsSource = locatielist;

        }
        public void dbquerysend()
        {
            

            try
            {
                string query = "INSERT INTO VM_Aanvragen(Datum,Naam,Vmnaam,OS,CPU,RAM,Netwerk,Folder,Datacenter,Datastore,Reden) VALUES (GETDATE(),@naam, @vmnaam,@os,@cpu,@ram, @netwerk, @folder,'Datacenter','disks',@reden);";
                datab.Command.Parameters.AddWithValue("@naam", username);
                datab.Command.Parameters.AddWithValue("@vmnaam", vmnaam);
                datab.Command.Parameters.AddWithValue("@os", os);
                datab.Command.Parameters.AddWithValue("@cpu", cpu);
                datab.Command.Parameters.AddWithValue("@ram", ram);
                datab.Command.Parameters.AddWithValue("@netwerk", netwerk);
                datab.Command.Parameters.AddWithValue("@folder", folder);
                datab.Command.Parameters.AddWithValue("@reden", reden);

                datab.Command.CommandText = query;
                datab.Command.ExecuteNonQuery();
                MessageBox.Show("Uw verzoek is ingediend");
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            vars();
           

        }

        
    }
}
