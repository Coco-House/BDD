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
    /// Interaction logic for ModuleCdR.xaml
    /// </summary>
    public partial class ModuleCdR : Window
    {
        public ModuleCdR()
        {
            InitializeComponent();
            if (ConnexionCompte.CdRConnecte == true)
            {
                DeconnexionButton.IsEnabled = true;
            }
            else
            {
                DeconnexionButton.IsEnabled = false;
            }
        }

        private void ModuleClientButton_click(object sender, RoutedEventArgs e)
        {
            ModuleClient window = new ModuleClient();
            window.Show();
            this.Close();
        }

        private void CreerRecette_click(object sender, RoutedEventArgs e)
        {
            CreerRecette window = new CreerRecette();
            window.Show();
            this.Close();
        }

        private void ConsulterSolde_click(object sender, RoutedEventArgs e)
        {
            AfficherProfilCdR window = new AfficherProfilCdR();
            window.Show();
            this.Close();
        }

        private void AfficherRecettes_click(object sender, RoutedEventArgs e)
        {
            AfficherRecettesCdR window = new AfficherRecettesCdR();
            window.Show();
            this.Close();

        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            DeconnexionButton.IsEnabled = false;

            ConnexionCompte.UnBlockCdR = false;
            ConnexionCompte.ClientConnecte = false; // pas necessaire car c'est surement un cdr connecte
            ConnexionCompte.CdRConnecte = false;
            ConnexionCompte.IdCdRConnecte = "";
            ConnexionCompte.EmailConnecte = "";

            MessageBox.Show("Deconnexion réussie ! Retour à la page d'accueil !", "Deconnexion !", MessageBoxButton.OK, MessageBoxImage.Information);
            PageD_accueil window = new PageD_accueil();
            window.Show();
            this.Close();
        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            PageD_accueil window = new PageD_accueil();
            window.Show();
            this.Close();
        }
    }
}
