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
using System.DirectoryServices.AccountManagement;


namespace Service_portaal
{
    /// <summary>
    /// Interaction logic for overview.xaml
    /// </summary>
    public partial class overview : Window
    {
        newvm nvm;
        //newvm nvm2;
        private string username;
        private string password;
        private string[] groepen;

        public overview()
        {
            InitializeComponent();
        }

        public overview(string username, string password, string [] groepen)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.groepen = groepen;

        }

      

        public void pagina()
        {
            System.Diagnostics.Process.Start("microsoft-edge:https://www.help.domainseclab.com/");
        }
        public void venster()
        {
            
            nvm = new newvm(username,password,groepen);// credits naar ralph FUCks
            nvm.Show();
            this.Hide();

        }
        private void tbtn_Click(object sender, RoutedEventArgs e)
        {
            pagina();
        }

        private void vmbtn_Click(object sender, RoutedEventArgs e)
        {
            venster();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
