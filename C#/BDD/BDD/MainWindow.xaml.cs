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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace BDD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string username;
        private static string password;
        public static List<Client> listeClients = new List<Client>();
        public static List<CdR> listeCdR = new List<CdR>();
        public static List<Fournisseur> listeFournisseurs = new List<Fournisseur>();
        public static List<Produit> listeProduits = new List<Produit>();
        public static List<Recette> listeRecettes = new List<Recette>();
        public static List<Cooking> listeCooking = new List<Cooking>();


        public static string Username
        {
            get { return username; }
        }

        public static string Password
        {
            get { return password; }
        }

        private static void MettreAJourAges()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commandAge = connection.CreateCommand();
            commandAge.CommandText = "SELECT idC,DateNaissance FROM projet.client;";

            MySqlDataReader readerAge;
            readerAge = commandAge.ExecuteReader();

            string idC = "";
            DateTime DateNaissance = new DateTime();
            int age = 0;
            List<string> listeidC = new List<string>();
            List<int> listeage = new List<int>();

            while (readerAge.Read())
            {
                idC = readerAge.GetString(0);
                DateNaissance = readerAge.GetDateTime(1);
                
                if ((DateTime.Now.Month == Convert.ToInt32(DateNaissance.Month) && DateTime.Now.Day >= Convert.ToInt32(DateNaissance.Day)) || (DateTime.Now.Month > Convert.ToInt32(DateNaissance.Month)))
                {
                    age = DateTime.Now.Year - Convert.ToInt32(DateNaissance.Year);
                }
                else
                {
                    age = DateTime.Now.Year - Convert.ToInt32(DateNaissance.Year) - 1;
                }

                listeidC.Add(idC);
                listeage.Add(age);
            }
            connection.Close();

            
           
            for(int i = 0; i <= listeidC.Count-1; i++)
            {        
                connection.Open();

                MySqlCommand commandUpdate = connection.CreateCommand();
                commandUpdate.CommandText = "UPDATE projet.client SET age=" + listeage[i] + " WHERE idC='" + listeidC[i] + "';";

                MySqlDataReader readerUpdate;
                readerUpdate = commandUpdate.ExecuteReader();

                while (readerUpdate.Read()) { }

                connection.Close();
            }
            MessageBox.Show("Mise a jour de la database reussie !");

        }

        private static void LoadDatabase()
        {
            MettreAJourAges();

            #region Client

            MainWindow.listeClients.Clear();

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commandRecherche = connection.CreateCommand();
            commandRecherche.CommandText = "SELECT idC,sexe,nomC,prenomC,DateNaissance,age,adresse,email,password,telC FROM projet.client;";

            MySqlDataReader readerRecherche;
            readerRecherche = commandRecherche.ExecuteReader();

            string idC = "";
            char sexe = ' ';
            string nomC = "";
            string prenomC = "";
            DateTime dateNaissance2 = new DateTime();
            string dateNaissance = "";
            int age = 0;
            string adresse = "";
            string email = "";
            string password = "";
            string telC = "";

            while (readerRecherche.Read())
            {
                idC = readerRecherche.GetString(0);
                sexe = readerRecherche.GetChar(1);
                nomC = readerRecherche.GetString(2);
                prenomC = readerRecherche.GetString(3);
                dateNaissance2 = readerRecherche.GetDateTime(4);

                dateNaissance = dateNaissance2.Year+"-"+dateNaissance2.Month+"-"+dateNaissance2.Day;
                
                age = readerRecherche.GetInt32(5);
                adresse = readerRecherche.GetString(6);
                email = readerRecherche.GetString(7);
                password = readerRecherche.GetString(8);
                telC = readerRecherche.GetString(9);
                Client newClient = new Client(idC, sexe, nomC, prenomC, dateNaissance, age, adresse, email, password, telC);
                MainWindow.listeClients.Add(newClient);
            }

            connection.Close();

            #endregion

            #region CdR

            MainWindow.listeCdR.Clear();

            connection.Open();

            MySqlCommand commandRechercheCdR = connection.CreateCommand();
            commandRechercheCdR.CommandText = "SELECT projet.client.idC,sexe,nomC,prenomC,DateNaissance,age,adresse,email,password,telC,cook,idCdR FROM projet.client,projet.cdR WHERE projet.client.idC = projet.cdR.idC;";

            MySqlDataReader readerRechercheCdR;
            readerRechercheCdR = commandRechercheCdR.ExecuteReader();

            string idC2 = "";
            char sexe2 = ' ';
            string nomC2 = "";
            string prenomC2 = "";
            DateTime dateNaissance2b = new DateTime();
            string dateNaissance1 = "";
            int age2 = 0;
            string adresse2 = "";
            string email2 = "";
            string password2 = "";
            string telC2 = "";
            int cook = 0;
            string idCdR = "";


            while (readerRechercheCdR.Read())
            {
                idC2 = readerRechercheCdR.GetString(0);
                sexe2 = readerRechercheCdR.GetChar(1);
                nomC2 = readerRechercheCdR.GetString(2);
                prenomC2 = readerRechercheCdR.GetString(3);
                dateNaissance2b = readerRechercheCdR.GetDateTime(4);

                dateNaissance1 = dateNaissance2b.Year + "-" + dateNaissance2b.Month + "-" + dateNaissance2b.Day;

                age2 = readerRechercheCdR.GetInt32(5);
                adresse2 = readerRechercheCdR.GetString(6);
                email2 = readerRechercheCdR.GetString(7);
                password2 = readerRechercheCdR.GetString(8);
                telC2 = readerRechercheCdR.GetString(9);
                cook = readerRechercheCdR.GetInt32(10);
                idCdR = readerRechercheCdR.GetString(11);

                CdR newCdR = new CdR(idC, sexe, nomC, prenomC, dateNaissance1, age, adresse, email, password, telC, idCdR, cook);
                MainWindow.listeCdR.Add(newCdR);
            }

            connection.Close();

            #endregion

            #region Recette

            MainWindow.listeRecettes.Clear();

            connection.Open();

            MySqlCommand commandRechercheR = connection.CreateCommand();
            commandRechercheR.CommandText = "SELECT idR,nomR,type,listeIngredients,descriptionR,prixR,remunerationCuisinier,idGratification,nbCook,idCdR FROM projet.recette;";

            MySqlDataReader readerRechercheR;
            readerRechercheR = commandRechercheR.ExecuteReader();

            string idR = "";
            string nomR = "";
            string type = "";
            string listeIngredients = "";
            string descriptionR = "";
            int prixR = 0;
            int remuneration = 0;
            string idGrat = "";
            int nbCook = 0;
            string idCdR2 = "";

            while (readerRechercheR.Read())
            {
                idR = readerRechercheR.GetString(0);
                nomR = readerRechercheR.GetString(1);
                type = readerRechercheR.GetString(2);
                listeIngredients = readerRechercheR.GetString(3);
                descriptionR = readerRechercheR.GetString(4);
                prixR = readerRechercheR.GetInt32(5);
                remuneration = readerRechercheR.GetInt32(6);
                idGrat = readerRechercheR.GetString(7);
                nbCook = readerRechercheR.GetInt32(8);
                idCdR2 = readerRechercheR.GetString(9);

                Recette newRecette = new Recette(idR, nomR, type, listeIngredients, descriptionR, prixR, remuneration, idGrat, nbCook, idCdR2);
                MainWindow.listeRecettes.Add(newRecette);
            }

            connection.Close();


            #endregion

            #region Produit 

            MainWindow.listeProduits.Clear();

            connection.Open();

            MySqlCommand commandRechercheP = connection.CreateCommand();
            commandRechercheP.CommandText = "SELECT nomP,categorieP,unite,stockActuel,stockMin,stockMax,idF FROM projet.produit;";

            MySqlDataReader readerRechercheP;
            readerRechercheP = commandRechercheP.ExecuteReader();

            string nomP = "";
            string categorieP = "";
            string unite = "";
            int stockActu = 0;
            int stockMin = 0;
            int stockMax = 0;
            string idF = "";

            while (readerRechercheP.Read())
            {
                nomP = readerRechercheP.GetString(0);
                categorieP = readerRechercheP.GetString(1);
                unite = readerRechercheP.GetString(2);
                stockActu = readerRechercheP.GetInt32(3);
                stockMin = readerRechercheP.GetInt32(4);
                stockMax = readerRechercheP.GetInt32(5);
                idF = readerRechercheP.GetString(6);

                Produit newProduit = new Produit(nomP, categorieP, unite, stockActu, stockMin, stockMax, idF);
                MainWindow.listeProduits.Add(newProduit);
            }

            connection.Close();


            #endregion

            #region Fournisseur 

            MainWindow.listeFournisseurs.Clear();

            connection.Open();

            MySqlCommand commandRechercheF = connection.CreateCommand();
            commandRechercheF.CommandText = "SELECT idF,nomF,telF FROM projet.fournisseur;";

            MySqlDataReader readerRechercheF;
            readerRechercheF = commandRechercheF.ExecuteReader();

            string idF2 = "";
            string nomF = "";
            string telF = "";

            while (readerRechercheF.Read())
            {
                idF2 = readerRechercheF.GetString(0);
                nomF = readerRechercheF.GetString(1);
                telF = readerRechercheF.GetString(2);

                Fournisseur newFournisseur = new Fournisseur(idF2, nomF, telF);
                MainWindow.listeFournisseurs.Add(newFournisseur);
            }

            connection.Close();


            #endregion

            #region Cooking 

            MainWindow.listeCooking.Clear();

            connection.Open();

            MySqlCommand commandRechercheC = connection.CreateCommand();
            commandRechercheC.CommandText = "SELECT idCooking FROM projet.Cooking;";

            MySqlDataReader readerRechercheC;
            readerRechercheC = commandRechercheC.ExecuteReader();

            string idCooking = "";

            while (readerRechercheC.Read())
            {
                idCooking = readerRechercheC.GetString(0);

                Cooking newCooking = new Cooking(idCooking);
                MainWindow.listeCooking.Add(newCooking);
            }

            connection.Close();


            #endregion

        }

        public MainWindow()
        {
            InitializeComponent();
            LoginButton.Visibility = Visibility.Hidden;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Connexion Réussie ! Vous pouvez maintenant accéder à l'application !", "Login Successful ! ", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadDatabase();
            PageD_accueil windowAccueil = new PageD_accueil();
            windowAccueil.Show();
            this.Close();
        }

        private void Valider2Button_Click(object sender, RoutedEventArgs e)
        {
            if (IDBox.Text != "" && PswdBox.Password != "")
            {
                username = IDBox.Text;
                password = PswdBox.Password;

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + username + ";PASSWORD=" + password;

                MySqlConnection connection = new MySqlConnection(connectionString);

              try
                {
                    connection.Open();
                    connection.Close();
                    LoginButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                catch
                {
                    MessageBox.Show("Username ou mot de passe erroné.", "Login Failed !", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Attention ! êtes-vous sûr de vouloir quitter ? ", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
            }

        }

    }
}
