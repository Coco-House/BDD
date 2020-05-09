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
            
            // if client ou cdr co

            /*
             disable
             tout sauf retour et tableau bord
             */

            // if admin

            // activer boutons,  connexion disabled 


            // if CdR co --> activer supprimer recette
        }

        private void ConnexionAdmin_Click(object sender, RoutedEventArgs e)
        {
            // avec mdp et username database
        }

        private void TableauBord_Click(object sender, RoutedEventArgs e)
        {
            // 3 checkboxs et 1 table
        }

        private void SupprimerRecette_Click(object sender, RoutedEventArgs e)
        {
            // combobox --> remplie de TOUTES les recettes si admin, sinon SES recettes
        }

        private void RajouterProduit_Click(object sender, RoutedEventArgs e)
        {
            // reprendre creer produit cdr
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            // Reprendre supprimer compte cdr --> avec checkbox : laisser en client ou pas
        }

        private void DeconnexionAdmin_Click(object sender, RoutedEventArgs e)
        {
            // deco admin
            // mise a jour boutons
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
