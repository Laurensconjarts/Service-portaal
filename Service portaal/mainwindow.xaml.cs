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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.DirectoryServices.AccountManagement;
using System.Windows.Controls.Primitives;

namespace Service_portaal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        overview No;
        overviewadmin Noa;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private string username;
        private string password;
        private string[] groepen;

        public void login()
        {

            PrincipalContext principalContext =
                 new PrincipalContext(ContextType.Domain, "192.168.8.40");
           
            username = utb.Text;

            password = ww_pb.Password.ToString();
            bool userValid = principalContext.ValidateCredentials(username, password);

            if (userValid == true)
            {
                grande();
                No = new overview(username, password, groepen);
                Noa = new overviewadmin(username, password, groepen);

                // credits naar ralph FUCks

                MessageBox.Show("Aangemeld");

                string administrator = Array.Find(groepen,
                       element => element.StartsWith("Administrator",
                       StringComparison.Ordinal));

                if(administrator == null)
                {
                No.Show();
                this.Hide();

                }
                if (administrator != null)
                {
                    Noa.Show();
                    this.Hide();

                }
            }
            else
            {
                MessageBox.Show("minderpuik");
            }

        }

        public void grande()
        {

            {
                
                using (var ctx = new PrincipalContext(ContextType.Domain, "192.168.8.40", username, password))
                using (var user = UserPrincipal.FindByIdentity(ctx, username))
                {
                    if (user != null)
                    {
                        groepen = user.GetGroups()
                            .Select(x => x.SamAccountName)
                            .ToArray();

                    }


                }



            }

        }
        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {

            login();
        }
    }
}
