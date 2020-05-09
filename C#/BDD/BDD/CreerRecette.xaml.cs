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
    /// Interaction logic for CreerRecette.xaml
    /// </summary>
    public partial class CreerRecette : Window
    {
        public static List<string> listeNomProduitsRecette = new List<string>();
        public static List<string> listeQuantitesRecette = new List<string>();
        public static List<Produit> listeNomNouveauxProduits = new List<Produit>();
        public static List<string> listeQuantiteNouveauxProduits = new List<string>();

        public CreerRecette()
        {
            InitializeComponent();
            // remplir les combobox depuis la liste et la database des produtis
        }

        private void TypeLostFocus(object sender, RoutedEventArgs e)
        {
            // verifier qu'il y a pas d'espace --> 1 mot
        }
        private void IdLostFocus(object sender, RoutedEventArgs e)
        {
            // verifier que c'est pas utilise + int
        }
        private void PrixLostFocus(object sender, RoutedEventArgs e)
        {
          // verifier que c'est des int
          // verifier qu'il est entre 10 et 40 cook
        }

        private void NouveauProduit_Click(object sender, RoutedEventArgs e)
        {
            // nvlle page
            // verifier nom PAS UTILISE

            // instancier avec calcul stock
            // ajouter a la liste nveau produits
        }

        private void Enlever_Click(object sender, RoutedEventArgs e)
        {
            // verifier combo box utilise (selectedindex != -1)
            // enlever du tableau
            // enlever de la liste recette
        }

        private void Rajouter_Click(object sender, RoutedEventArgs e)
        {
            // verifier combo box utilise (selectedindex != -1)
            // rajouter au tableau
            // rajouter au combo liste
            // rajouter liste recette
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            // creer classe
            // prendre liste noms -->  rajouter ;
            // prendre liste quantites -->  rajouter ;
            // si listeNveau.Count != 0 --> rajouter le nom de la listeNveaux produtis a la fin apres ; puis quantites

            // insert into sql les nouveaux produits (liste)

            // PUIS!!!! insert into sql (recette)


            // load database
            // vider les listes
            // quiter
        }

        private void FinaliserButton_Click(object sender, RoutedEventArgs e)
        {
            // verifier tout est rempli
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // quitter
            // vider les listes
        }
    }
}
