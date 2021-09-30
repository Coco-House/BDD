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
using System.IO;

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

        public static List<Client> listeClientsSemainePrec = new List<Client>();
        public static List<CdR> listeCdRSemainePrec = new List<CdR>();
        public static List<Fournisseur> listeFournisseursSemainePrec = new List<Fournisseur>();
        public static List<Produit> listeProduitsSemainePrec = new List<Produit>();
        public static List<Recette> listeRecettesSemainePrec = new List<Recette>();
        public static List<Cooking> listeCookingSemainePrec = new List<Cooking>();

        public static List<int> listeNbSemainesSansCommande = new List<int>();


        public static string Username
        {
            get { return username; }
        }

        public static string Password
        {
            get { return password; }
        }

        /// <summary>
        /// Permet de garder les ages des clients à jour, avec un maximum de précision
        /// </summary>
        public static void MettreAJourAges()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

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

        }

        /// <summary>
        /// Lit la database et instance chaque tuple en utilisant les classes C#
        /// </summary>
        public static void LoadDatabase()
        {
            MettreAJourAges();

            #region Client

            MainWindow.listeClients.Clear();

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commandRecherche = connection.CreateCommand();
            commandRecherche.CommandText = "SELECT idC,sexe,UPPER(nomC),prenomC,DateNaissance,age,adresse,email,password,telC FROM projet.client;";

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
            commandRechercheCdR.CommandText = "SELECT projet.client.idC,sexe,UPPER(nomC),prenomC,DateNaissance,age,adresse,email,password,telC,cook,idCdR FROM projet.client,projet.cdR WHERE projet.client.idC = projet.cdR.idC;";

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
            commandRechercheR.CommandText = "SELECT idR,nomR,type,listeIngredients,quantites,descriptionR,prixR,remunerationCuisinier,idGratification,nbCook,idCdR,nbCommandes FROM projet.recette;";

            MySqlDataReader readerRechercheR;
            readerRechercheR = commandRechercheR.ExecuteReader();

            string idR = "";
            string nomR = "";
            string type = "";
            string listeIngredients = "";
            string quantites = "";
            string descriptionR = "";
            int prixR = 0;
            int remuneration = 0;
            string idGrat = "";
            int nbCook = 0;
            int nbCommandes = 0;
            string idCdR2 = "";

            while (readerRechercheR.Read())
            {
                idR = readerRechercheR.GetString(0);
                nomR = readerRechercheR.GetString(1);
                type = readerRechercheR.GetString(2);
                listeIngredients = readerRechercheR.GetString(3);
                quantites = readerRechercheR.GetString(4);
                descriptionR = readerRechercheR.GetString(5);
                prixR = readerRechercheR.GetInt32(6);
                remuneration = readerRechercheR.GetInt32(7);
                idGrat = readerRechercheR.GetString(8);
                nbCook = readerRechercheR.GetInt32(9);
                idCdR2 = readerRechercheR.GetString(10);
                nbCommandes = readerRechercheR.GetInt32(11);

                Recette newRecette = new Recette(idR, nomR, type, listeIngredients,quantites, descriptionR, prixR, remuneration,nbCommandes, idGrat, nbCook, idCdR2);
                MainWindow.listeRecettes.Add(newRecette);
            }

            connection.Close();


            #endregion

            #region Produit 

            MainWindow.listeProduits.Clear();

            connection.Open();

            MySqlCommand commandRechercheP = connection.CreateCommand();
            commandRechercheP.CommandText = "SELECT nomP,categorieP,unite,stockActuel,stockMin,stockMax,idF FROM projet.produit ORDER BY nomP;";

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

        /// <summary>
        /// Vérifie si un produit a été utilisé, ou pas, depuis la semaine précédente
        /// </summary>
        public static void VerifierSiProduitCommandé()
        {
            LoadDatabaseSemainePrec();
            LoadDatabase();
            LoadDatabaseSemainePrec();

            int compteur = 0;
            foreach(Produit p in listeProduits)
            {
                if (p.StockActuel == listeProduitsSemainePrec[compteur].StockActuel)
                {
                    // il n'a pas ete achete 
                    listeNbSemainesSansCommande[compteur] += 1; // compte le nombre de semaines passées avant qu'il soit commandé
                }
                else
                {
                    listeNbSemainesSansCommande[compteur] = 0;
                }
                compteur++;
            }
        }

        /// <summary>
        /// Enregistre la database en début de semaine sous format fichier .csv 
        /// </summary>
        public static void SaveDatabaseSemainePrec()
        {
            #region Client

            StreamWriter fichEct = new StreamWriter("ClientsSemPrec.csv", false);

            string ligne = "";

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commandRecherche = connection.CreateCommand();
            commandRecherche.CommandText = "SELECT idC,sexe,UPPER(nomC),prenomC,DateNaissance,age,adresse,email,password,telC FROM projet.client;";

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

                dateNaissance = dateNaissance2.Year + "-" + dateNaissance2.Month + "-" + dateNaissance2.Day;

                age = readerRecherche.GetInt32(5);
                adresse = readerRecherche.GetString(6);
                email = readerRecherche.GetString(7);
                password = readerRecherche.GetString(8);
                telC = readerRecherche.GetString(9);

                ligne = idC + "," + sexe + "," + nomC + "," + prenomC + "," + dateNaissance + "," + age + "," + adresse + "," + email + "," + password + "," + telC;
                fichEct.WriteLine(ligne);
            }

            connection.Close();
            fichEct.Close();

            #endregion

            #region CdR

            StreamWriter fichEct2 = new StreamWriter("CdRsSemPrec.csv", false);

            string ligne2 = "";

            connection.Open();

            MySqlCommand commandRechercheCdR = connection.CreateCommand();
            commandRechercheCdR.CommandText = "SELECT projet.client.idC,sexe,UPPER(nomC),prenomC,DateNaissance,age,adresse,email,password,telC,cook,idCdR FROM projet.client,projet.cdR WHERE projet.client.idC = projet.cdR.idC;";

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

                ligne2 = idC2 + "," + sexe2 + "," + nomC2 + "," + prenomC2 + "," + dateNaissance1 + "," + age2 + "," + adresse2 + "," + email2 + "," + password2 + "," + telC2 + "," + cook + "," + idCdR;
                fichEct2.WriteLine(ligne2);
            }

            connection.Close();
            fichEct2.Close();

            #endregion

            #region Recette

            StreamWriter fichEct3 = new StreamWriter("RecettesSemPrec.csv", false);

            string ligne3 = "";


            connection.Open();

            MySqlCommand commandRechercheR = connection.CreateCommand();
            commandRechercheR.CommandText = "SELECT idR,nomR,type,listeIngredients,quantites,descriptionR,prixR,remunerationCuisinier,idGratification,nbCook,idCdR,nbCommandes FROM projet.recette;";

            MySqlDataReader readerRechercheR;
            readerRechercheR = commandRechercheR.ExecuteReader();

            string idR = "";
            string nomR = "";
            string type = "";
            string listeIngredients = "";
            string quantites = "";
            string descriptionR = "";
            int prixR = 0;
            int remuneration = 0;
            string idGrat = "";
            int nbCook = 0;
            int nbCommandes = 0;
            string idCdR2 = "";

            while (readerRechercheR.Read())
            {
                idR = readerRechercheR.GetString(0);
                nomR = readerRechercheR.GetString(1);
                type = readerRechercheR.GetString(2);
                listeIngredients = readerRechercheR.GetString(3);
                quantites = readerRechercheR.GetString(4);
                descriptionR = readerRechercheR.GetString(5);
                prixR = readerRechercheR.GetInt32(6);
                remuneration = readerRechercheR.GetInt32(7);
                idGrat = readerRechercheR.GetString(8);
                nbCook = readerRechercheR.GetInt32(9);
                idCdR2 = readerRechercheR.GetString(10);
                nbCommandes = readerRechercheR.GetInt32(11);

                ligne3 = idR + "," + nomR + "," + type + "," + listeIngredients + "," + quantites + "," + descriptionR + "," + prixR + "," + remuneration + "," + idGrat + "," + nbCook + "," + idCdR2 + "," + nbCommandes;
                fichEct3.WriteLine(ligne3);
            }

            connection.Close();
            fichEct3.Close();

            #endregion

            #region Produit 

            StreamWriter fichEct4 = new StreamWriter("ProduitsSemPrec.csv", false);

            string ligne4 = "";

            connection.Open();

            MySqlCommand commandRechercheP = connection.CreateCommand();
            commandRechercheP.CommandText = "SELECT nomP,categorieP,unite,stockActuel,stockMin,stockMax,idF FROM projet.produit ORDER BY nomP;";

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

                ligne4 = nomP + "," + categorieP + "," + unite + "," + stockActu + "," + stockMin + "," + stockMax + "," + idF;
                fichEct4.WriteLine(ligne4);
            }

            connection.Close();
            fichEct4.Close();

            #endregion

            #region Fournisseur 

            StreamWriter fichEct5 = new StreamWriter("FournisseursSemPrec.csv", false);

            string ligne5 = "";

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

                ligne5 = idF2 + "," + nomF + "," + telF;
                fichEct5.WriteLine(ligne5);
            }

            connection.Close();
            fichEct5.Close();

            #endregion

            #region Cooking 

            StreamWriter fichEct6 = new StreamWriter("CookingsSemPrec.csv", false);

            string ligne6 = "";

            connection.Open();

            MySqlCommand commandRechercheC = connection.CreateCommand();
            commandRechercheC.CommandText = "SELECT idCooking FROM projet.Cooking;";

            MySqlDataReader readerRechercheC;
            readerRechercheC = commandRechercheC.ExecuteReader();

            string idCooking = "";

            while (readerRechercheC.Read())
            {
                idCooking = readerRechercheC.GetString(0);

                ligne6 = idCooking;
                fichEct6.WriteLine(ligne6);
            }

            connection.Close();
            fichEct6.Close();

            #endregion

            #region Liste Nombre Semaines Passées Sans Commandes (Par Produit)

            StreamWriter fichEct7 = new StreamWriter("NbSemainesSansCommade.csv", false);
            
            foreach(int nb in listeNbSemainesSansCommande)
            {
                fichEct7.WriteLine(nb);
            }

            fichEct7.Close();

            #endregion
        }


        /// <summary>
        /// Lit la database de la semaine dernièr à partir du fichier .csv
        /// </summary>
        public static void LoadDatabaseSemainePrec()
        {
            MettreAJourAges();

            #region Client

            StreamReader fichLect = new StreamReader("ClientsSemPrec.csv");

            listeClientsSemainePrec.Clear();

            string ligne = "";

            string[] data;
            char[] sep = new char[1] { ',' };

            while (fichLect.Peek() > 0)
            {
                ligne = fichLect.ReadLine();
                data = ligne.Split(sep);
                string idC = data[0];
                char sexe = Convert.ToChar(data[1]);
                string nomC = data[2];
                string prenomC = data[3];
                string dateNaissance = data[4];
                int age = Convert.ToInt32(data[5]);
                string adresse = data[6]+","+data[7]+","+data[8];
                string email = data[9];
                string password = data[10];
                string telC = data[11];

                Client newClient = new Client(idC, sexe, nomC, prenomC, dateNaissance, age, adresse, email, password, telC);
                listeClientsSemainePrec.Add(newClient);
            }

            fichLect.Close();

            #endregion

            #region CdR

            StreamReader fichLect2 = new StreamReader("CdRsSemPrec.csv");

            listeCdRSemainePrec.Clear();

            string ligne2 = "";

            string[] data2;
            char[] sep2 = new char[1] { ',' };

            while (fichLect2.Peek() > 0)
            {
                ligne2 = fichLect2.ReadLine();
                data2 = ligne2.Split(sep2);
                string idC = data2[0];
                char sexe = Convert.ToChar(data2[1]);
                string nomC = data2[2];
                string prenomC = data2[3];
                string dateNaissance = data2[4];
                int age = Convert.ToInt32(data2[5]);
                string adresse = data2[6]+","+data2[7]+","+data2[8];
                string email = data2[9];
                string password = data2[10];
                string telC = data2[11];
                int cook = Convert.ToInt32(data2[12]);
                string idCdR = data2[13];

                CdR newCdR = new CdR(idC, sexe, nomC, prenomC, dateNaissance, age, adresse, email, password, telC,idCdR,cook);
                listeCdRSemainePrec.Add(newCdR);
            }

            fichLect2.Close();

            #endregion

            #region Recette

            StreamReader fichLect3 = new StreamReader("RecettesSemPrec.csv");

            listeRecettesSemainePrec.Clear();

            string ligne3 = "";

            string[] data3;
            char[] sep3 = new char[1] { ',' };

            while (fichLect3.Peek() > 0)
            {
                ligne3 = fichLect3.ReadLine();
                data3 = ligne3.Split(sep3);

                string idR = data3[0];
                string nomR = data3[1];
                string type = data3[2];
                string listeIngredients = data3[3];
                string quantites = data3[4];
                string descriptionR = data3[5];
                int prixR = Convert.ToInt32(data3[6]);
                int remuneration = Convert.ToInt32(data3[7]);
                string idGrat = data3[8];
                int nbCook = Convert.ToInt32(data3[9]);
                int nbCommandes = Convert.ToInt32(data3[11]);
                string idCdR2 = data3[10];

                Recette newRecette = new Recette(idR,nomR,type,listeIngredients,quantites,descriptionR,prixR,remuneration,nbCommandes,idGrat,nbCook,idCdR2);
                listeRecettesSemainePrec.Add(newRecette);
            }

            fichLect3.Close();



            #endregion

            #region Produit 

            StreamReader fichLect4 = new StreamReader("ProduitsSemPrec.csv");

            listeProduitsSemainePrec.Clear();

            string ligne4 = "";

            string[] data4;
            char[] sep4 = new char[1] { ',' };

            while (fichLect4.Peek() > 0)
            {
                ligne4 = fichLect4.ReadLine();
                data4 = ligne4.Split(sep4);

                string nomP = data4[0];
                string categorieP = data4[1];
                string unite = data4[2];
                int stockActu = Convert.ToInt32(data4[3]);
                int stockMin = Convert.ToInt32(data4[4]);
                int stockMax = Convert.ToInt32(data4[5]);
                string idF = data4[6];

                Produit newProduit = new Produit(nomP, categorieP, unite, stockActu, stockMin, stockMax, idF);
                listeProduitsSemainePrec.Add(newProduit);
            }

            fichLect4.Close();

            #endregion

            #region Fournisseur 

            StreamReader fichLect5 = new StreamReader("FournisseursSemPrec.csv");

            listeFournisseursSemainePrec.Clear();

            string ligne5 = "";

            string[] data5;
            char[] sep5 = new char[1] { ',' };

            while (fichLect5.Peek() > 0)
            {
                ligne5 = fichLect5.ReadLine();
                data5 = ligne5.Split(sep5);

                string idF2 = data5[0];
                string nomF = data5[1];
                string telF = data5[2];

                Fournisseur newFournisseur = new Fournisseur(idF2, nomF, telF);
                listeFournisseursSemainePrec.Add(newFournisseur);
            }

            fichLect5.Close();

            #endregion

            #region Cooking 

            StreamReader fichLect6 = new StreamReader("CookingsSemPrec.csv");

            listeCookingSemainePrec.Clear();

            string ligne6 = "";

            string[] data6;
            char[] sep6 = new char[1] { ',' };

            while (fichLect6.Peek() > 0)
            {
                ligne6 = fichLect6.ReadLine();
                data6 = ligne6.Split(sep6);


                string idCooking = data6[0];

                Cooking newCooking = new Cooking(idCooking);
                listeCookingSemainePrec.Add(newCooking);
            }

            fichLect6.Close();

            #endregion

            #region Liste Nombre Semaines Passées Sans Commandes (Par Produit)

            StreamReader fichLect7 = new StreamReader("NbSemainesSansCommade.csv");

            listeNbSemainesSansCommande.Clear();

            string ligne7 = "";

            string[] data7;
            char[] sep7 = new char[1] { ',' };

            while (fichLect7.Peek() > 0)
            {
                ligne7 = fichLect7.ReadLine();
                data7 = ligne7.Split(sep7);


                int nbSemaines = Convert.ToInt32(data7[0]);

                listeNbSemainesSansCommande.Add(nbSemaines);
            }

            fichLect7.Close();

            #endregion

        }

        public MainWindow()
        {
            InitializeComponent();
            LoginButton.Visibility = Visibility.Hidden;
            ModuleGestion.aReapprovisionne = false;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Connexion Réussie ! Vous pouvez maintenant accéder à l'application !", "Login Successful ! ", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadDatabase();
            LoadDatabaseSemainePrec();
            MessageBox.Show("Mise a jour de la database reussie !","Update successful ! ",MessageBoxButton.OK,MessageBoxImage.Information);
            
            if(DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                SaveDatabaseSemainePrec();
                VerifierSiProduitCommandé();
                MessageBox.Show("Mise a jour de la database de la semaine dernière reussie !", "Update successful ! ", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            LoadDatabaseSemainePrec();

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

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + username + ";PASSWORD=" + password;

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
