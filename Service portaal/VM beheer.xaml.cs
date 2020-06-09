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
    /// Interaction logic for VM_beheer.xaml
    /// </summary>
    public partial class VM_beheer : Window
    {
        private string username;
        private string password;
        private string[] groepen;
        db datab = new db();
       public static int aanvraagid;
       public static DateTime datum;
       public static string naam;
       public static string vmnaam;
       public static string os;
       public static int cpu;
       public static int ram;
       public static string netwerk;
       public static string folder;
       public static string datacenter;
       public static string datastore;
       public static string reden;
        public VM_beheer()
        {
            
            InitializeComponent();
            laden();
        }
        public VM_beheer(string username, string password, string [] groepen)
        {

            this.username = username;
            this.password = password;
            this.groepen = groepen;
            InitializeComponent();
            laden();
        }

            

        public void laden()
        {
            goedkeuren_btn.Visibility = Visibility.Collapsed;
            afwijzen_btn.Visibility = Visibility.Collapsed;
            vms_dg.ItemsSource = datab.Vmspecificaties(0);
        }

        public void scontract(out string content)
        {
            var aanvraagid = vms_dg.SelectedCells[0];

            content = (aanvraagid.Column.GetCellContent(aanvraagid.Item) as TextBlock).Text;

        }
        public void inladen()
        {
            string content;
            scontract(out content);
            datab.Vmspecificaties(Convert.ToInt32(content));
            dti_lb.Content = datum;
            naami_lb.Content = naam;
            netwerki_lb.Content = netwerk;
            osi_lb.Content = os;
            vmnaami_lb.Content = vmnaam;
            folderi_lb.Content = folder;
            cpui_lb.Content = cpu;
            rami_lb.Content = ram;
            redeni_tb.Text = reden;







        }
        private void vms_dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goedkeuren_btn.Visibility = Visibility.Visible;
            afwijzen_btn.Visibility = Visibility.Visible;
            inladen();
            vms_dg.SelectedItem = null;

        }

        private void script_create()
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = $@"C:\Users\RENDER\PycharmProjects\sfeer3\CreateVM.py {vmnaam} {datacenter} {folder} {datastore} ""VM Network"" {os}";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    
                }
            }
        }

        private void script_cpu()
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = $@"C:\Users\RENDER\PycharmProjects\sfeer3\CPU.py {vmnaam} {cpu}";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    
                }
            }
        }

        private void script_ram()
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = $@"C:\Users\RENDER\PycharmProjects\sfeer3\RAM.py {vmnaam} {ram}";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    
                }
            }
        }

        private void script_netwerk()
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = $@"C:\Users\RENDER\PycharmProjects\sfeer3\Ethernet.py {vmnaam} {netwerk} {datacenter}";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    
                }
            }
        }
        private void goedkeuren_btn1_Click(object sender, RoutedEventArgs e)
        {
            script_create();
            script_cpu();
            script_ram();
            script_netwerk();
            dbquerysend();
            
        }

        public void dbquerysend()
        {


            try
            {
                string query = "INSERT INTO VM_archief(AanvraagID, Datum,Naam,Vmnaam,OS,CPU,RAM,Netwerk,Folder,Datacenter,Datastore,Reden) VALUES (@aanvraagid,GETDATE(),@naam, @vmnaam,@os,@cpu,@ram, @netwerk, @folder,'Datacenter','disks',@reden);";
                datab.Command.Parameters.AddWithValue("@aanvraagid", aanvraagid);
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
                datab.Command.Parameters.Clear();
                query = "Delete From VM_Aanvragen where AanvraagID = @aanvraagid";
                datab.Command.Parameters.AddWithValue("@aanvraagid", aanvraagid);
                datab.Command.CommandText = query;
                datab.Command.ExecuteNonQuery();
                MessageBox.Show($"Aaanvraag: {aanvraagid} is verwerkt!");
                datab.Command.Parameters.Clear();
                laden();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void afwijzen_btn1_Click(object sender, RoutedEventArgs e)
        {
            dbquerysend();
        }
    }
}
