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
    /// Interaction logic for PasserCommande.xaml
    /// </summary>
    public partial class PasserCommande : Window
    {

        public static List<string> listeIdRecettesCommandees = new List<string>();

        public PasserCommande()
        {
            InitializeComponent();

            try
            {
                MainWindow.LoadDatabase();

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand commandRechercheR = connection.CreateCommand();
                commandRechercheR.CommandText = "SELECT R.type,R.nomR AS Nom_Recette,R.idR AS id_Recette,R.prixR AS prix_Cook,R.idCdR AS id_Createur_de_Recette,C.nomC AS Nom_Createur_de_Recette,C.prenomC AS Prenom_Createur_de_Recette FROM projet.recette AS R, projet.client AS C, projet.cdr AS CdR WHERE R.idCdR = CdR.idCdR AND CdR.idC = C.idC ORDER BY R.type,R.nomR;";
                commandRechercheR.ExecuteNonQuery();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(commandRechercheR);
                DataTable dataRecettes = new DataTable("Liste Recettes");
                dataAdapter.Fill(dataRecettes);
                
                DataSQL.ItemsSource = dataRecettes.DefaultView;
                dataAdapter.Update(dataRecettes);

                connection.Close();

                connection.Open();

                MySqlCommand commandRemplir = connection.CreateCommand();
                commandRemplir.CommandText = "SELECT idR FROM projet.recette ORDER BY idR;";

                MySqlDataReader readerRemplir;
                readerRemplir = commandRemplir.ExecuteReader();

                string idRecette = "";

                while (readerRemplir.Read())
                {
                    idRecette = readerRemplir.GetString(0);

                    ListeRecettesCombo.Items.Add(idRecette);
                    ListeRecettesDetail.Items.Add(idRecette);
                }

                connection.Close();

                foreach(string id in listeIdRecettesCommandees)
                {
                    ListeRecettesSupprimer.Items.Add(id);
                }

                Compteur.Content = listeIdRecettesCommandees.Count;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }

        private void Panier_Click(object sender, RoutedEventArgs e)
        {
            Panier window = new Panier();
            window.Show();
            this.Close();
        }

        private void AjouterPanier_Click(object sender, RoutedEventArgs e)
        {
            if(ListeRecettesCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir une recette avant de cliquer ! ", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                listeIdRecettesCommandees.Add(ListeRecettesCombo.SelectedItem.ToString());
                ListeRecettesSupprimer.Items.Add(ListeRecettesCombo.SelectedItem.ToString());
                Compteur.Content = listeIdRecettesCommandees.Count;
                ListeRecettesCombo.SelectedIndex = -1;
            }
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            if(ListeRecettesDetail.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir une recette avant de cliquer ! ", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DetailRecette window = new DetailRecette(ListeRecettesDetail.SelectedItem.ToString());
                ListeRecettesSupprimer.SelectedIndex = -1;
                window.Show();
                this.Close();
            }
        }

        private void SupprimerPanier_Click(object sender, RoutedEventArgs e)
        {
            if(ListeRecettesSupprimer.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir une recette avant de cliquer ! ", "Erreur !",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                listeIdRecettesCommandees.Remove(ListeRecettesSupprimer.SelectedItem.ToString());
                MessageBox.Show("Recette enlevée du panier !");
                Compteur.Content = listeIdRecettesCommandees.Count;
                ListeRecettesSupprimer.Items.RemoveAt(ListeRecettesSupprimer.SelectedIndex);
                ListeRecettesSupprimer.SelectedIndex = -1;
            }
        }

        private void Finaliser_Click(object sender, RoutedEventArgs e)
        {
            Panier window = new Panier();
            window.Show();
            MessageBox.Show("Veuillez vérifier votre panier avant de procéder au paiement !", "Information !", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Attention ! êtes-vous sûr de vouloir abandonner la commande ?", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                listeIdRecettesCommandees.Clear();
                ModuleClient window = new ModuleClient();
                window.Show();
                this.Close();
            }
        }

    }
}
