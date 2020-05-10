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
    /// Interaction logic for Demo5.xaml
    /// </summary>
    public partial class Demo5 : Window
    {
        public Demo5()
        {
            InitializeComponent();

            ProduitComboBox.Items.Clear();

            TableDonnees.Visibility = Visibility.Visible;
            ListeProdRectangle.Visibility = Visibility.Visible;
            ListeProdLabel.Visibility = Visibility.Visible;

            TableRecettes.Visibility = Visibility.Hidden;
            listeRecettesLabel.Visibility = Visibility.Hidden;
            ListeRecettesRectangle.Visibility = Visibility.Hidden;
            
            
            RetourCheckBox.IsEnabled = false;
            RetourCheckBox.IsChecked = false;


            DataTable datademo5 = new DataTable("Demo 5");

            datademo5.Columns.Add("Nom Produit");
            datademo5.Columns.Add("Catégorie Produit");
            datademo5.Columns.Add("Unité");
            datademo5.Columns.Add("Stock Min", typeof(int));
            datademo5.Columns.Add("Stock Actuel", typeof(int));
            datademo5.Columns.Add("Stock Max", typeof(int));
            datademo5.Columns.Add("Id Fournisseur");

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commande = connection.CreateCommand();
            commande.CommandText = "SELECT * FROM projet.produit WHERE stockActuel <= 2 * stockMin;";

            MySqlDataReader reader;
            reader = commande.ExecuteReader();


            while (reader.Read())
            {
                ProduitComboBox.Items.Add(reader.GetString(0));

                datademo5.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(4), reader.GetInt32(3), reader.GetInt32(5), reader.GetString(6));
            }

            connection.Close();


            datademo5.DefaultView.Sort = "Nom Produit asc";
            TableDonnees.ItemsSource = datademo5.DefaultView;
        }

        private void AfficherButton_Click(object sender, RoutedEventArgs e)
        {
            if(SaisieManuelle.Text == "" && ProduitComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir un produit dans le comboBox ou de le saisir manuellement dans le textBox ! ", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(SaisieManuelle.Text != "" && ProduitComboBox.SelectedIndex != -1)
            {
                MessageBox.Show("Veuillez choisir entre comboBox et saisie manuelle , et non pas les deux ! ", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                ProduitComboBox.SelectedIndex = -1;
                SaisieManuelle.Text = string.Empty;
            }
            else
            {
                if(SaisieManuelle.Text != "")
                {
                    string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();

                    MySqlCommand commande = connection.CreateCommand();
                    commande.CommandText = "SELECT * FROM projet.produit WHERE stockActuel <= 2 * stockMin AND nomP='"+SaisieManuelle.Text+"';";

                    MySqlDataReader reader;
                    reader = commande.ExecuteReader();

                    string existe = "";

                    while (reader.Read())
                    {
                        existe = reader.GetString(0);    
                    }

                    connection.Close();

                    if (existe == "")
                    {
                        MessageBox.Show("Le nom du produit entré manuellement ne correspond à aucun des produits affichés ! ", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                        SaisieManuelle.Text = string.Empty;
                    }
                    else
                    {
                        DataTable dataRec = new DataTable("Recettes");
                        
                        dataRec.Columns.Add("Id Recette");
                        dataRec.Columns.Add("Nom Recette");
                        dataRec.Columns.Add("Quantite Dans Recette",typeof(int));
                        dataRec.Columns.Add("Unite");

                        connection.Open();

                        MySqlCommand commandeU = connection.CreateCommand();
                        commandeU.CommandText = "SELECT unite FROM projet.produit WHERE nomP='" + SaisieManuelle.Text + "';";

                        MySqlDataReader readerU;
                        readerU = commandeU.ExecuteReader();

                        string unite = "";

                        while (readerU.Read())
                        {
                            unite = readerU.GetString(0);
                        }

                        connection.Close();

                        connection.Open();

                        MySqlCommand commande2 = connection.CreateCommand();
                        commande2.CommandText = "SELECT idR,nomR,quantites,listeIngredients FROM projet.recette WHERE listeIngredients LIKE '%;" + SaisieManuelle.Text + "%' OR listeIngredients LIKE '%" + SaisieManuelle.Text+ ";%' OR listeIngredients LIKE '%;" + SaisieManuelle.Text + ";%';";

                        MySqlDataReader reader2;
                        reader2 = commande2.ExecuteReader();

                        while (reader2.Read())
                        {
                            string idR = reader2.GetString(0);
                            string nomR = reader2.GetString(1);
                            string quantites = reader2.GetString(2);
                            string listeIngredients = reader2.GetString(3);

                            string[] ingredients = listeIngredients.Split(';');
                            string[] listeQuantites = quantites.Split(';');

                            int indiceProd = 0;
                            foreach(string prod in ingredients)
                            {
                                if (prod == SaisieManuelle.Text)
                                {
                                    break;
                                }
                                indiceProd++;
                            }

                            int quantite = Convert.ToInt32(listeQuantites[indiceProd]);

                            dataRec.Rows.Add(idR, nomR, quantite, unite);
                        }

                        connection.Close();


                        dataRec.DefaultView.Sort = "Id Recette asc";
                        TableRecettes.ItemsSource = dataRec.DefaultView;

                        RetourCheckBox.IsEnabled = true;


                        listeRecettesLabel.Visibility = Visibility.Visible;
                        ListeRecettesRectangle.Visibility = Visibility.Visible;

                        ListeProdRectangle.Visibility = Visibility.Hidden;
                        ListeProdLabel.Visibility = Visibility.Hidden;


                        TableDonnees.Visibility = Visibility.Hidden;
                        TableRecettes.Visibility = Visibility.Visible;
                    }

                }
                else if(ProduitComboBox.SelectedIndex != -1)
                {
                    DataTable dataRec = new DataTable("Recettes");

                    dataRec.Columns.Add("Id Recette");
                    dataRec.Columns.Add("Nom Recette");
                    dataRec.Columns.Add("Quantite Dans Recette", typeof(int));
                    dataRec.Columns.Add("Unite");

                    string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                    MySqlConnection connection = new MySqlConnection(connectionString);


                    connection.Open();

                    MySqlCommand commandeU = connection.CreateCommand();
                    commandeU.CommandText = "SELECT unite FROM projet.produit WHERE nomP='" + ProduitComboBox.SelectedItem.ToString() + "';";

                    MySqlDataReader readerU;
                    readerU = commandeU.ExecuteReader();

                    string unite = "";

                    while (readerU.Read())
                    {
                        unite = readerU.GetString(0);
                    }

                    connection.Close();

                    connection.Open();

                    MySqlCommand commande2 = connection.CreateCommand();
                    commande2.CommandText = "SELECT idR,nomR,quantites,listeIngredients FROM projet.recette WHERE listeIngredients LIKE '%;" + ProduitComboBox.SelectedItem.ToString() + "%' OR listeIngredients LIKE '%" + ProduitComboBox.SelectedItem.ToString() + ";%' OR listeIngredients LIKE '%;" + ProduitComboBox.SelectedItem.ToString() + ";%';";

                    MySqlDataReader reader2;
                    reader2 = commande2.ExecuteReader();

                    while (reader2.Read())
                    {
                        string idR = reader2.GetString(0);
                        string nomR = reader2.GetString(1);
                        string quantites = reader2.GetString(2);
                        string listeIngredients = reader2.GetString(3);

                        string[] ingredients = listeIngredients.Split(';');
                        string[] listeQuantites = quantites.Split(';');

                        int indiceProd = 0;
                        foreach (string prod in ingredients)
                        {
                            if (prod == ProduitComboBox.SelectedItem.ToString())
                            {
                                break;
                            }
                            indiceProd++;
                        }

                        int quantite = Convert.ToInt32(listeQuantites[indiceProd]);

                        dataRec.Rows.Add(idR, nomR, quantite, unite);
                    }

                    connection.Close();


                    dataRec.DefaultView.Sort = "Id Recette asc";
                    TableRecettes.ItemsSource = dataRec.DefaultView;

                    RetourCheckBox.IsEnabled = true;


                    listeRecettesLabel.Visibility = Visibility.Visible;
                    ListeRecettesRectangle.Visibility = Visibility.Visible;

                    ListeProdRectangle.Visibility = Visibility.Hidden;
                    ListeProdLabel.Visibility = Visibility.Hidden;


                    TableDonnees.Visibility = Visibility.Hidden;
                    TableRecettes.Visibility = Visibility.Visible;
                }
            }
        }

        private void RetourCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TableDonnees.Visibility = Visibility.Visible;
            TableRecettes.Visibility = Visibility.Hidden;

            listeRecettesLabel.Visibility = Visibility.Hidden;
            ListeRecettesRectangle.Visibility = Visibility.Hidden;

            ListeProdRectangle.Visibility = Visibility.Visible;
            ListeProdLabel.Visibility = Visibility.Visible;
            
            RetourCheckBox.IsEnabled = false;
            RetourCheckBox.IsChecked = false;

            ProduitComboBox.SelectedIndex = -1;
            SaisieManuelle.Text = string.Empty;
        }

        private void RetourPageAcc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous êtes arrivés à la fin de la démo !", "Fin !", MessageBoxButton.OK, MessageBoxImage.Information);

            PageD_accueil window = new PageD_accueil();
            window.Show();
            this.Close();
        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            Demo4 window = new Demo4();
            window.Show();
            this.Close();
        }
    }
}
