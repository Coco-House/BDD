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

            if(ConnexionCompte.ClientConnecte == true || ConnexionCompte.CdRConnecte == true)
            {
                LoginButton.IsEnabled = false;
                ConnexionButton.IsEnabled = false;
                DeconnexionButton.IsEnabled = true;
                SupprimerCompteButton.IsEnabled = true;
            }
            else
            {
                LoginButton.IsEnabled = true;
                ConnexionButton.IsEnabled = true;
                DeconnexionButton.IsEnabled = false;
                SupprimerCompteButton.IsEnabled = false;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginPage window = new LoginPage();
            window.Show();
            this.Close();
        }

        private void PasserUneCommande_Click(object sender, RoutedEventArgs e)
        {
            PasserCommande window = new PasserCommande();
            window.Show();
            this.Close();
        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            PageD_accueil window = new PageD_accueil();
            window.Show();
            this.Close();
        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Attention ! êtes-vous sûr de vouloir vous deconnecter ? ", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                ConnexionCompte.UnBlockCdR = false;
                ConnexionCompte.ClientConnecte = false;
                ConnexionCompte.CdRConnecte = false;
                ConnexionCompte.IdCdRConnecte = "";
                ConnexionCompte.EmailConnecte = "";
                LoginButton.IsEnabled = true;
                PasserCommande.listeIdRecettesCommandees.Clear();
                ModuleClient window = new ModuleClient();
                window.Show();
                this.Close();
            }
            else
            {
            }

        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            ConnexionCompte window = new ConnexionCompte();
            window.Show();
            this.Close();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            SupprimerCompte window = new SupprimerCompte();
            window.Show();
            this.Close();
        }
    }
}
