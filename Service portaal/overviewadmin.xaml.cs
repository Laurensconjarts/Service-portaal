using System;
using System.Collections.Generic;
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

namespace Service_portaal
{
    /// <summary>
    /// Interaction logic for overviewadmin.xaml
    /// </summary>
    public partial class overviewadmin : Window
    {
        newvm nvm;
        VM_beheer vmb;
        private string username;
        private string password;
        private string[] groepen;
        public overviewadmin()
        {
            InitializeComponent();
        }

        public overviewadmin(string username, string password, string[] groepen)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.groepen = groepen;

        }


        public void pagina()
        {
            System.Diagnostics.Process.Start("microsoft-edge:https://www.seclabsupport.com/osticket/");
        }
        public void venster_aanvraag()
        {

            nvm = new newvm(username, password, groepen);// credits naar ralph FUCks
            nvm.Show();
            this.Hide();

        }

        public void venster_beheer()
        {
            vmb = new VM_beheer(username, password, groepen);
            
            vmb.Show();
            this.Hide();

        }
        private void tbtn_Click(object sender, RoutedEventArgs e)
        {
            pagina();
        }

        private void vmbtn_Click(object sender, RoutedEventArgs e)
        {
            venster_aanvraag();

        }

        private void vmbtn2_Click(object sender, RoutedEventArgs e)
        {
            venster_beheer();
        }
    }
}
