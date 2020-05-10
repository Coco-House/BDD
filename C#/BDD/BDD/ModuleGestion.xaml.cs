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
    /// Interaction logic for ModuleGestion.xaml
    /// </summary>
    public partial class ModuleGestion : Window
    {
        public ModuleGestion()
        {
            InitializeComponent();
            
            if(ConnexionCompte.CdRConnecte == false && ConnexionCompte.ClientConnecte==false && ConnexionCompteAdmin.AdminConnecte == false)
            {
                ConnexionAdminButton.IsEnabled = true;
                SupprimerRecetteButton.IsEnabled = false;
                RajouterProduitButton.IsEnabled = false;
                SupprimerCompteButton.IsEnabled = false;
                DeconnexionAdminButton.IsEnabled = false;
            }
            else if(ConnexionCompte.CdRConnecte == true)
            {
                ConnexionAdminButton.IsEnabled = false;
                SupprimerRecetteButton.IsEnabled = true;
                RajouterProduitButton.IsEnabled = false;
                SupprimerCompteButton.IsEnabled = false;
                DeconnexionAdminButton.IsEnabled = false;
            }
            else if(ConnexionCompte.ClientConnecte == true)
            {
                ConnexionAdminButton.IsEnabled = false;
                SupprimerRecetteButton.IsEnabled = false;
                RajouterProduitButton.IsEnabled = false;
                SupprimerCompteButton.IsEnabled = false;
                DeconnexionAdminButton.IsEnabled = false;
            }
            else if(ConnexionCompteAdmin.AdminConnecte == true)
            {
                ConnexionAdminButton.IsEnabled = false;
                SupprimerRecetteButton.IsEnabled = true;
                RajouterProduitButton.IsEnabled = true;
                SupprimerCompteButton.IsEnabled = true;
                DeconnexionAdminButton.IsEnabled = true;
            }

        }

        private void ConnexionAdmin_Click(object sender, RoutedEventArgs e)
        {
            ConnexionCompteAdmin window = new ConnexionCompteAdmin();
            window.Show();
            this.Close();
        }

        private void TableauBord_Click(object sender, RoutedEventArgs e)
        {
            TableauBord window = new TableauBord();
            window.Show();
            this.Close();
        }

        private void SupprimerRecette_Click(object sender, RoutedEventArgs e)
        {
            SupprimerUneRecette window = new SupprimerUneRecette();
            window.Show();
            this.Close();
        }

        private void RajouterProduit_Click(object sender, RoutedEventArgs e)
        {
            CreerProduitAdmin window = new CreerProduitAdmin();
            window.Show();
            this.Close();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            SupprimerCompteAdmin window = new SupprimerCompteAdmin();
            window.Show();
            this.Close();
        }

        private void DeconnexionAdmin_Click(object sender, RoutedEventArgs e)
        {
            ConnexionCompteAdmin.AdminConnecte = false;
            ConnexionAdminButton.IsEnabled = true;
            SupprimerRecetteButton.IsEnabled = false;
            RajouterProduitButton.IsEnabled = false;
            SupprimerCompteButton.IsEnabled = false;
            DeconnexionAdminButton.IsEnabled = false;
        }

        private void Reapprovisionnement_Click(object sender, RoutedEventArgs e)
        {
            // if jour=dimance --> enabled --> faire calcul
            // sinon --> not enabled


            // liste stockActu de chaque produit --> si le stockAct de ces produits a pas ete modifie par rapport au stockAct de mtn --> compteurCommande ++
            // si il se fait commande --> remettre a 0
            // SI compteurCommande = 4; --> ca a pas ete utilise pendant un mois ==> stock /2 (calcul)

            // fichier test.xml --> mettre a jour stocks
            // trouver les produits qui ont besoin de reapp.
            // creer le fichier Reappro.xml (ecraser celui de test)

        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            PageD_accueil window = new PageD_accueil();
            window.Show();
            this.Close();
        }
    }
}
