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
using System.Data;
using MySql.Data.MySqlClient;

namespace BDD
{
    /// <summary>
    /// Interaction logic for Panier.xaml
    /// </summary>
    public partial class Panier : Window
    {
        public Panier()
        {
            InitializeComponent();

            int prixCook = 0;

            DataTable dataPanier = new DataTable("Liste Recettes");

            dataPanier.Columns.Add("Quantité_Commandée");
            dataPanier.Columns.Add("Type");
            dataPanier.Columns.Add("Nom Recette");
            dataPanier.Columns.Add("Id Recette");
            dataPanier.Columns.Add("Prix (Cook)");
            dataPanier.Columns.Add("Id Createur de Recette");
            dataPanier.Columns.Add("Nom Createur de Recette");
            dataPanier.Columns.Add("Prenom Createur de Recette");

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);


            List<string> listeIdRajoutes = new List<string>();

            foreach (string id in PasserCommande.listeIdRecettesCommandees)
            {
                connection.Open();

                MySqlCommand commandRemplir = connection.CreateCommand();
                commandRemplir.CommandText = "SELECT R.type,R.nomR AS Nom_Recette,R.idR AS id_Recette,R.prixR,R.idCdR AS id_Createur_de_Recette,UPPER(C.nomC) AS Nom_Createur_de_Recette,C.prenomC AS Prenom_Createur_de_Recette FROM projet.recette AS R, projet.client AS C, projet.cdr AS CdR WHERE R.idCdR = CdR.idCdR AND CdR.idC = C.idC AND idR='" + id + "' ORDER BY R.type,R.nomR;";

                MySqlDataReader readerRemplir;
                readerRemplir = commandRemplir.ExecuteReader();

                while (readerRemplir.Read())
                {
                    prixCook += readerRemplir.GetInt32(3);

                    if (!listeIdRajoutes.Contains(id))
                    {
                        dataPanier.Rows.Add(PasserCommande.listeIdRecettesCommandees.Count(item => item == id), readerRemplir.GetString(0), readerRemplir.GetString(1), readerRemplir.GetString(2), readerRemplir.GetInt32(3), readerRemplir.GetString(4), readerRemplir.GetString(5), readerRemplir.GetString(6));
                        listeIdRajoutes.Add(id);
                    }
                }


                connection.Close();

            }

            dataPanier.DefaultView.Sort = "Quantité_Commandée desc";
            PanierData.ItemsSource = dataPanier.DefaultView;

            PrixCook.Content = prixCook;
            PrixEuros.Content = Recette.ConvertirEnEuros(prixCook);
        }


        private void MettreAJourStockEtPoints()
        {
            foreach (string id in PasserCommande.listeIdRecettesCommandees)
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand commandRechercheR = connection.CreateCommand();
                commandRechercheR.CommandText = "SELECT nbCommandes,prixR,remunerationCuisinier,listeIngredients,quantites,idCdR FROM projet.recette WHERE idR='" + id + "';";
                commandRechercheR.ExecuteNonQuery();

                MySqlDataReader readerR;
                readerR = commandRechercheR.ExecuteReader();

                int nbCommandes = 0;
                int prixR = 0;
                int remuneration = 0;
                string idCdR = "";
                string listeIngredientsSQL = "";
                string listeQuantitesSQL = "";
                string[] listeIngredients;
                string[] listeQuantites;

                while (readerR.Read())
                {
                    nbCommandes = readerR.GetInt32(0);
                    prixR = readerR.GetInt32(1);
                    remuneration = readerR.GetInt32(2);
                    listeIngredientsSQL = readerR.GetString(3);
                    listeQuantitesSQL = readerR.GetString(4);
                    idCdR = readerR.GetString(5);
                }


                listeIngredients = listeIngredientsSQL.Split(';');
                listeQuantites = listeQuantitesSQL.Split(';');



                connection.Close();


                nbCommandes += 1;
                
                if(nbCommandes == 11) // on a fait l'hypothese que c'est "depasse strictement 10"
                {
                    prixR += 2;
                }

                if(nbCommandes == 51) // on a fait l'hypothese que c'est "depasse strictement 10"
                {
                    prixR += 5;
                    remuneration = 4;
                }

                for(int i = 0; i< listeIngredients.Length; i++)
                {
                    connection.Open();

                    MySqlCommand commandUpdate = connection.CreateCommand();
                    commandUpdate.CommandText = "UPDATE projet.produit SET stockActuel=stockActuel-" + listeQuantites[i] + " WHERE nomP='" + listeIngredients[i] + "';";

                    MySqlDataReader readerUpdate;
                    readerUpdate = commandUpdate.ExecuteReader();

                    while (readerUpdate.Read()) { }

                    connection.Close();
                }

                // Mettre a jour le nbCommandes et modifications du prix et de la remuneration si necessaire

                connection.Open();

                MySqlCommand commandUpdate2 = connection.CreateCommand();
                commandUpdate2.CommandText = "UPDATE projet.recette SET nbCommandes=" + nbCommandes + ",prixR="+prixR+ ",remunerationCuisinier="+remuneration+" WHERE idR='" + id + "';";

                MySqlDataReader readerUpdate2;
                readerUpdate2 = commandUpdate2.ExecuteReader();

                while (readerUpdate2.Read()) { }

                connection.Close();

                // Mettre a jour les points cook du CdR
                
                connection.Open();

                MySqlCommand commandUpdate3 = connection.CreateCommand();
                commandUpdate3.CommandText = "UPDATE projet.cdr SET cook=cook+" + remuneration + " WHERE projet.cdr.idCdR='"+idCdR+"';";

                MySqlDataReader readerUpdate3;
                readerUpdate3 = commandUpdate3.ExecuteReader();

                while (readerUpdate3.Read()) { }

                connection.Close();

            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            PasserCommande window = new PasserCommande();
            window.Show();

        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FinaliserButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasserCommande.listeIdRecettesCommandees.Count == 0)
            {
                MessageBox.Show("Vous n'avez rien commandé ! ");
            }
            else
            {
                if (ConnexionCompte.ClientConnecte == false && ConnexionCompte.CdRConnecte == false)
                {
                    this.Close();
                    ConnexionCompte window = new ConnexionCompte();
                    window.Show();
                }
                else
                {
                    if (ConnexionCompte.CdRConnecte == true)
                    {
                        string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                        MySqlConnection connection = new MySqlConnection(connectionString);


                        connection.Open();

                        MySqlCommand commandRemplir = connection.CreateCommand();
                        commandRemplir.CommandText = "SELECT cook FROM projet.cdr WHERE idCdR ='" + ConnexionCompte.IdCdRConnecte + "';";

                        MySqlDataReader readerRemplir;
                        readerRemplir = commandRemplir.ExecuteReader();

                        int balanceCook = 0;

                        while (readerRemplir.Read())
                        {
                            balanceCook = readerRemplir.GetInt32(0);
                        }


                        connection.Close();

                        if (balanceCook < Convert.ToInt32(PrixCook.Content))
                        {
                            MessageBox.Show("Vous n'avez pas assez de points cook ! ", "Erreur ! ", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            var result = MessageBox.Show("La somme à payer est de  " + PrixCook.Content + " cook. Vous avez " + balanceCook + " cook ! Etes-vous sûr de vouloir procéder au paiement ? Reste : "+(balanceCook-Convert.ToInt32(PrixCook.Content))+" cook !", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Information);

                            if (result == MessageBoxResult.Yes)
                            {
                                int newBalance = balanceCook - (Convert.ToInt32(PrixCook.Content));

                                connection.Open();

                                MySqlCommand commandUpdate = connection.CreateCommand();
                                commandUpdate.CommandText = "UPDATE projet.cdr SET cook=" + newBalance + " WHERE idCdR='" + ConnexionCompte.IdCdRConnecte + "';";

                                MySqlDataReader readerUpdate;
                                readerUpdate = commandUpdate.ExecuteReader();

                                while (readerUpdate.Read()) { }

                                connection.Close();

                                MettreAJourStockEtPoints();

                                MessageBox.Show("Paiement réussi !", "Success !", MessageBoxButton.OK, MessageBoxImage.Information);

                                MainWindow.LoadDatabase();
                                PasserCommande.listeIdRecettesCommandees.Clear();

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Paiement annulé !", "Information !", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                    else
                    {
                        var result = MessageBox.Show("La somme à payer est de  " + PrixEuros.Content + " euros ! Etes-vous sûr de vouloir procéder au paiement ?", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Information);

                        if (result == MessageBoxResult.Yes)
                        {
                            MettreAJourStockEtPoints();
                            MessageBox.Show("Paiement réussi !", "Success !", MessageBoxButton.OK, MessageBoxImage.Information);

                            MainWindow.LoadDatabase();
                            PasserCommande.listeIdRecettesCommandees.Clear();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Paiement annulé !", "Information !", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
        }
    }
}
