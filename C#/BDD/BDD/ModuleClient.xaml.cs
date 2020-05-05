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

namespace BDD
{
    /// <summary>
    /// Interaction logic for ModuleClient.xaml
    /// </summary>
    public partial class ModuleClient : Window
    {

        public ModuleClient()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginPage window = new LoginPage();
            window.Show();
            this.Close();
        }

        private void PasserUneCommande_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            PageD_accueil window = new PageD_accueil();
            window.Show();
            this.Close();
        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
