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

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

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

            PrixCook.Content = prixCook + " cook";
            PrixEuros.Content = Recette.ConvertirEnEuros(prixCook) + " euros";
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
                    ConnexionCompte window = new ConnexionCompte();
                    window.Show();
                }
                else
                {
                    if (ConnexionCompte.CdRConnecte == true)
                    {
                        string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

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


                        var result = MessageBox.Show("La somme à payer est de  " + PrixCook.Content + " cook. Vous avez " + balanceCook + " cook ! Etes-vous sûr de vouloir procéder au paiement ?", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Information);

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

                            foreach (string id in PasserCommande.listeIdRecettesCommandees)
                            {
                                /*
* compteur de commande de la recette ++
* si le nombre de commande d'une recette (EN PRENANT EN COMPTE LA COMMANDE EN COURS) > 10 --> prix vente augemente de 2 cook (%10, Prix += 2)
* Meme chose, si ca depasse 50, remuneration passe de 2 à 4 cook
* Mettre a jour le stocs des produits utilises pour realiser ces plats commandes
*/
                                connection.Open();

                                MySqlCommand commandRechercheR = connection.CreateCommand();
                                commandRechercheR.CommandText = "SELECT nbCommandes,prixR,remunerationCuisinier,listeIngredients,quantites FROM projet.recette WHERE idR='"+id+"';";
                                commandRechercheR.ExecuteNonQuery();

                                MySqlDataReader readerR;
                                readerR = commandRechercheR.ExecuteReader();

                                string idRecette = "";

                                while (readerR.Read())
                                {
                                    idRecette = readerR.GetString(0);

                                }

                                connection.Close();

                                connection.Open();
                                //update
                                connection.Close();

             
                            }

                            MessageBox.Show("Paiement réussi !", "Success !", MessageBoxButton.OK, MessageBoxImage.Information);

                            MainWindow.LoadDatabase();
                            PasserCommande.listeIdRecettesCommandees.Clear();

                            ModuleClient window = new ModuleClient();
                            window.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Paiement annulé !", "Information !", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        var result = MessageBox.Show("La somme à payer est de  " + PrixEuros.Content + " euros ! Etes-vous sûr de vouloir procéder au paiement ?", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Information);

                        if (result == MessageBoxResult.Yes)
                        {

                            MessageBox.Show("Paiement réussi !", "Success !", MessageBoxButton.OK, MessageBoxImage.Information);

                            MainWindow.LoadDatabase();
                            PasserCommande.listeIdRecettesCommandees.Clear();

                            ModuleClient window = new ModuleClient();
                            window.Show();
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
