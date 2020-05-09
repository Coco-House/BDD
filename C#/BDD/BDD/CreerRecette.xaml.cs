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
using System.Globalization;
using MySql.Data.MySqlClient;

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


        private static string nomRec = "";
        private static int indiceType = -1;
        private static string idRec = "";
        private static int prixRec = 0;
        private static string description = "";


        public CreerRecette()
        {
            InitializeComponent();
            ValiderButton.Visibility = Visibility.Hidden;

            try
            {
                TypesCombo.Items.Clear();
                listeSupprimerCombo.Items.Clear();
                listeProduitsCombo.Items.Clear();

                MainWindow.LoadDatabase();

                // Remplir les combobox

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand commandRemplir = connection.CreateCommand();
                commandRemplir.CommandText = "SELECT nomP FROM projet.produit ORDER BY nomP;";

                MySqlDataReader readerRemplir;
                readerRemplir = commandRemplir.ExecuteReader();


                while (readerRemplir.Read())
                {
                    listeProduitsCombo.Items.Add(readerRemplir.GetString(0));
                }

                connection.Close();

                connection.Open();

                MySqlCommand commandRemplir2 = connection.CreateCommand();
                commandRemplir2.CommandText = "SELECT DISTINCT type FROM projet.recette ORDER BY type;";

                MySqlDataReader readerRemplir2;
                readerRemplir2 = commandRemplir2.ExecuteReader();


                while (readerRemplir2.Read())
                {
                    if (readerRemplir2.GetString(0) != "Autre")
                    {
                        TypesCombo.Items.Add(readerRemplir2.GetString(0));
                    }
                }

                TypesCombo.Items.Add("Autre");

                connection.Close();


                foreach (string nomP in listeNomProduitsRecette)
                {
                    listeSupprimerCombo.Items.Add(nomP);
                }

                foreach (Produit p in listeNomNouveauxProduits)
                {
                    listeSupprimerCombo.Items.Add(p.NomP);
                    listeProduitsCombo.Items.Add(p.NomP);
                }

                TypesCombo.SelectedIndex = indiceType;

                NomLabel.Text = nomRec;
                IdLabel.Text = idRec;
                CookLabel.Text = prixRec.ToString();
                EurosLabel.Content = Recette.ConvertirEnEuros(prixRec);
                textDescription.Text = description;


                // Remplir la table

                DataTable dataProduits = new DataTable("Liste Produits");

                dataProduits.Columns.Add("Nom Produit");
                dataProduits.Columns.Add("Quantité");
                dataProduits.Columns.Add("Unité");

                int compteur = 0;

                foreach (string nom in listeNomProduitsRecette)
                {
                    string connectionStringData = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                    MySqlConnection connectionData = new MySqlConnection(connectionStringData);
                    connectionData.Open();

                    MySqlCommand commandData = connectionData.CreateCommand();
                    commandData.CommandText = "SELECT unite FROM projet.produit WHERE nomP='" + nom + "';";

                    MySqlDataReader readerData;
                    readerData = commandData.ExecuteReader();

                    string unite = "";

                    while (readerData.Read())
                    {
                        unite = readerData.GetString(0);
                    }

                    connectionData.Close();

                    dataProduits.Rows.Add(nom, listeQuantitesRecette[compteur], unite);
                    compteur++;
                }

                if (listeNomNouveauxProduits.Count != 0)
                {
                    int compteur2 = 0;
                    foreach (Produit p in listeNomNouveauxProduits)
                    {
                        dataProduits.Rows.Add(p.NomP, listeQuantiteNouveauxProduits[compteur2], p.Unite);
                        compteur2++;
                    }
                }

                dataProduits.DefaultView.Sort = "Nom Produit asc";
                TableIngred.ItemsSource = dataProduits.DefaultView;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void TypeChanged(object sender, RoutedEventArgs e)
        {
            indiceType = TypesCombo.SelectedIndex;
        }
     
        private void IdLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(((TextBox)sender).Text);

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT idR FROM projet.recette WHERE idR='R" + ((TextBox)sender).Text + "';";

                MySqlDataReader reader;
                reader = command.ExecuteReader();

                string idExiste = "";

                while (reader.Read())
                {
                    idExiste = reader.GetString(0);
                }

                connection.Close();

                if (idExiste != "")
                {
                    MessageBox.Show("L'id existe déjà, veuillez en choisir un autre !", "Doublon !", MessageBoxButton.OK, MessageBoxImage.Error);
                    IdLabel.Text = string.Empty;
                    idRec = "";
                }
                else
                {
                    idRec = IdLabel.Text;
                }
            }
            catch
            {
                MessageBox.Show("Vous devez entrez des chiffres.", "Syntax !", MessageBoxButton.OK, MessageBoxImage.Error);
                IdLabel.Text = string.Empty;
                idRec = "";
            }
        }
        private void DescriptionLostFocus(object sender, RoutedEventArgs e)
        {
            description = textDescription.Text;
        }
        private void NomLostFocus(object sender, RoutedEventArgs e)
        {
            nomRec = NomLabel.Text;
        }
        private void ComboBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (listeProduitsCombo.SelectedIndex != -1)
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT unite FROM projet.produit WHERE nomP='" + listeProduitsCombo.SelectedItem.ToString() + "';";

                MySqlDataReader reader;
                reader = command.ExecuteReader();

                string unite = "";

                while (reader.Read())
                {
                    unite = reader.GetString(0);
                }

                connection.Close();


                UniteLabel.Content = unite;

            }
        }


        private void QuantiteLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(((TextBox)sender).Text);
                if (listeProduitsCombo.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez choisir un produit avant !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    QuantiteText.Text = string.Empty;
                }
                else
                {
                    if (Convert.ToInt32(((TextBox)sender).Text) <= 0)
                    {
                        MessageBox.Show("La quantité doit être strictement positive !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                        QuantiteText.Text = string.Empty;
                    }
                    else
                    {
                        string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                        MySqlConnection connection = new MySqlConnection(connectionString);
                        connection.Open();

                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT stockMax,unite FROM projet.produit WHERE nomP='" + listeProduitsCombo.SelectedItem.ToString() + "';";

                        MySqlDataReader reader;
                        reader = command.ExecuteReader();

                        int stockMax = 0;
                        string unite = "";

                        while (reader.Read())
                        {
                            stockMax = reader.GetInt32(0);
                            unite = reader.GetString(1);
                        }

                        connection.Close();

                        if (Convert.ToInt32(((TextBox)sender).Text) >= stockMax)
                        {
                            MessageBox.Show("La quantité doit être inférieure au stock maximum de ce produit (" + stockMax + " " + unite + ") !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                            QuantiteText.Text = string.Empty;
                        }
                        else
                        {
                            UniteLabel.Content = unite;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vous devez entrez des chiffres.", "Syntax !", MessageBoxButton.OK, MessageBoxImage.Error);
                QuantiteText.Text = string.Empty;
            }
        }

        private void PrixLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(((TextBox)sender).Text);

                if (Convert.ToInt32(((TextBox)sender).Text) < 10 || Convert.ToInt32(((TextBox)sender).Text) > 40)
                {
                    MessageBox.Show("Le prix doit être entre 10 et 40 cook !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    CookLabel.Text = string.Empty;
                    prixRec = 0;
                    EurosLabel.Content = "";
                }
                else
                {
                    prixRec = Convert.ToInt32(((TextBox)sender).Text);
                    EurosLabel.Content = Recette.ConvertirEnEuros(Convert.ToInt32(((TextBox)sender).Text));
                }
            }
            catch
            {
                MessageBox.Show("Vous devez entrez des chiffres.", "Syntax !", MessageBoxButton.OK, MessageBoxImage.Error);
                CookLabel.Text = string.Empty;
                prixRec = 0;
                EurosLabel.Content = "";
            }
        }



        private void Enlever_Click(object sender, RoutedEventArgs e)
        {
            if (listeSupprimerCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Attention ! Il faut choisir un produit avant d'ajouter !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                if (listeNomProduitsRecette.Contains(listeSupprimerCombo.SelectedItem.ToString()))
                {
                    int indiceProd = listeNomProduitsRecette.IndexOf(listeSupprimerCombo.SelectedItem.ToString());

                    listeNomProduitsRecette.Remove(listeSupprimerCombo.SelectedItem.ToString());
                    listeQuantitesRecette.RemoveAt(indiceProd);

                    listeSupprimerCombo.Items.Remove(listeSupprimerCombo.SelectedItem.ToString());
                    listeSupprimerCombo.SelectedIndex = -1;


                    CreerRecette window = new CreerRecette();
                    window.Show();
                    this.Close();   // pour remettre a jour la table

                }
                else
                {
                    int indice = 0;
                    foreach (Produit p in listeNomNouveauxProduits)
                    {
                        if (p.NomP == listeSupprimerCombo.SelectedItem.ToString())
                        {
                            break;
                        }

                        indice++;
                    }

                    listeNomNouveauxProduits.RemoveAt(indice);
                    listeQuantiteNouveauxProduits.RemoveAt(indice);
                    listeSupprimerCombo.Items.Remove(listeSupprimerCombo.SelectedItem.ToString());
                    listeSupprimerCombo.SelectedIndex = -1;

                    CreerRecette window = new CreerRecette();
                    window.Show();
                    this.Close();   // pour remettre a jour la table
                }
            }
        }

        private void Rajouter_Click(object sender, RoutedEventArgs e)
        {
            if (listeProduitsCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Attention ! Il faut choisir un produit avant d'ajouter !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (QuantiteText.Text == "")
            {
                MessageBox.Show("Attention ! Il faut saisir la quantité avant d'ajouter !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (listeNomProduitsRecette.Contains(listeProduitsCombo.SelectedItem.ToString()))
                {
                    MessageBox.Show("Attention ! Vous avez déjà rajouté ce produit !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    QuantiteText.Text = "";
                    UniteLabel.Content = "";
                    listeProduitsCombo.SelectedIndex = -1;
                }
                else
                {
                    listeNomProduitsRecette.Add(listeProduitsCombo.SelectedItem.ToString());
                    listeSupprimerCombo.Items.Add(listeProduitsCombo.SelectedItem.ToString());
                    listeProduitsCombo.SelectedIndex = -1;
                    listeQuantitesRecette.Add(QuantiteText.Text);

                    CreerRecette window = new CreerRecette();
                    window.Show();
                    this.Close();   // pour remettre a jour la table
                }
            }

        }

        private void FinaliserButton_Click(object sender, RoutedEventArgs e)
        {
            if (NomLabel.Text != "" && TypesCombo.SelectedIndex != -1 && IdLabel.Text != "" && CookLabel.Text != "" && textDescription.Text != "" && (listeNomProduitsRecette.Count != 0 || listeNomNouveauxProduits.Count != 0))
            {
                if((textDescription.Text.Contains("\'") && !textDescription.Text.Contains("\\\'")) || textDescription.Text.Contains("\\\"") )
                {
                    MessageBox.Show("La description de la recette contient les caractères \' ou \\\" ! Veuillez les enlever ou rajouter un \\ avant ces caractères !","Erreur !",MessageBoxButton.OK,MessageBoxImage.Information);
                }
                else
                {
                    ValiderButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            string listeIngred = "";
            string quantites = "";

            if(listeNomProduitsRecette.Count != 0)
            {
                for (int i = 0; i < listeNomProduitsRecette.Count - 1; i++)
                {
                    listeIngred += listeNomProduitsRecette[i] + ";";
                    quantites += listeQuantitesRecette[i] + ";";
                }

                listeIngred += listeNomProduitsRecette[listeNomProduitsRecette.Count - 1];
                quantites += listeQuantitesRecette[listeNomProduitsRecette.Count - 1];
            }

            if (listeNomNouveauxProduits.Count != 0)
            {
                if(listeNomProduitsRecette.Count != 0)
                {
                    listeIngred += ";";
                    quantites += ";";
                }

                for (int j = 0; j < listeNomNouveauxProduits.Count - 1; j++)
                {
                    listeIngred += listeNomNouveauxProduits[j].NomP + ";";
                    quantites += listeQuantiteNouveauxProduits[j] + ";";

                    // Inserer les nouveaux produits dans la database

                    string connectionString1 = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                    MySqlConnection connection1 = new MySqlConnection(connectionString1);
                    connection1.Open();


                    MySqlCommand command1 = connection1.CreateCommand();

                    string nomP = listeNomNouveauxProduits[j].NomP;
                    string categorieP = listeNomNouveauxProduits[j].CategorieP;
                    string unite = listeNomNouveauxProduits[j].Unite;
                    int stockAct = listeNomNouveauxProduits[j].StockActuel;
                    int stockMini = listeNomNouveauxProduits[j].StockMin;
                    int stockMax = listeNomNouveauxProduits[j].StockMax;
                    string idF = listeNomNouveauxProduits[j].IdF;

                    command1.CommandText = " INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('" + nomP + "','" + categorieP + "','" + unite + "'," + stockAct + "," + stockMini + "," + stockMax + ",'" + idF + "');";

                    MySqlDataReader reader1;
                    reader1 = command1.ExecuteReader();

                    while (reader1.Read()) { }

                    connection1.Close();

                }

                int dernierInd = listeNomNouveauxProduits.Count - 1;

                listeIngred += listeNomNouveauxProduits[dernierInd].NomP;
                quantites += listeQuantiteNouveauxProduits[dernierInd];

                // Inserer les nouveaux produits dans la database

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                string nomP2 = listeNomNouveauxProduits[dernierInd].NomP;
                string categorieP2 = listeNomNouveauxProduits[dernierInd].CategorieP;
                string unite2 = listeNomNouveauxProduits[dernierInd].Unite;
                int stockAct2 = listeNomNouveauxProduits[dernierInd].StockActuel;
                int stockMini2 = listeNomNouveauxProduits[dernierInd].StockMin;
                int stockMax2 = listeNomNouveauxProduits[dernierInd].StockMax;
                string idF2 = listeNomNouveauxProduits[dernierInd].IdF;

                command.CommandText = "INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('" + nomP2 + "','" + categorieP2 + "','" + unite2 + "'," + stockAct2 + "," + stockMini2 + "," + stockMax2 + ",'" + idF2 + "');";


                MySqlDataReader reader;
                reader = command.ExecuteReader();

                while (reader.Read()) { }

                connection.Close();

                

            }

            // Inserer la recette dans la database 

            string connectionStringR = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connectionR = new MySqlConnection(connectionStringR);
            connectionR.Open();

            MySqlCommand commandR = connectionR.CreateCommand();

            string idR = "R" + IdLabel.Text;
            string nomR = NomLabel.Text;
            string type = TypesCombo.SelectedItem.ToString();

            string descriptionR = textDescription.Text;
            int priXR = Convert.ToInt32(CookLabel.Text);
            string idGrat = "GratR" + IdLabel.Text;
            int nbCook = 2;
            string idCdR = ConnexionCompte.IdCdRConnecte;

            commandR.CommandText = "INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`quantites`,`descriptionR`,`prixR`,`remunerationCuisinier`,`nbCommandes`,`idGratification`,`nbCook`,`idCdR`) VALUES ('" + idR + "','" + nomR + "','" + type + "','" + listeIngred + "','" + quantites + "','" + descriptionR + "'," + priXR + "," + 2 + "," + 0 + ",'" + idGrat + "'," + nbCook + ",'" + idCdR + "');";


            MySqlDataReader readerR;
            readerR = commandR.ExecuteReader();

            while (readerR.Read()) { }

            connectionR.Close();

            MainWindow.LoadDatabase();
            listeNomNouveauxProduits.Clear();
            listeNomProduitsRecette.Clear();
            listeQuantiteNouveauxProduits.Clear();
            listeQuantitesRecette.Clear();


            nomRec = "";
            idRec = "";
            prixRec = 0;
            EurosLabel.Content = "";
            description = "";
            indiceType = -1;

            // Gratifier le createur de la recette de nbCook points

            connectionR.Open();

            MySqlCommand commandUpdate = connectionR.CreateCommand();
            commandUpdate.CommandText = "UPDATE projet.cdr SET cook=cook+" + nbCook + " WHERE idCdR='" + ConnexionCompte.IdCdRConnecte + "';";

            MySqlDataReader readerUpdate;
            readerUpdate = commandUpdate.ExecuteReader();

            while (readerUpdate.Read()) { }

            connectionR.Close();

            MessageBox.Show("La recette a bien été créée et rajouté à la database ! ", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            
            MainWindow.LoadDatabase();

            ModuleCdR window = new ModuleCdR();
            window.Show();
            this.Close();

        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Attention ! êtes-vous sûr de vouloir abandonner la création ?", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                listeNomNouveauxProduits.Clear();
                listeNomProduitsRecette.Clear();
                listeQuantiteNouveauxProduits.Clear();
                listeQuantitesRecette.Clear();


                nomRec = "";
                idRec = "";
                prixRec = 0;
                EurosLabel.Content = "";
                description = "";
                indiceType = -1;

                ModuleCdR window = new ModuleCdR();
                window.Show();
                this.Close();
            }
        }

        private void NouveauProduit_Click(object sender, RoutedEventArgs e)
        {
            CreerProduitCdR window = new CreerProduitCdR();
            window.Show();
            this.Close();
        }
    }
}
