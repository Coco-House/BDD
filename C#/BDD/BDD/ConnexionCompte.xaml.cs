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
using MySql.Data.MySqlClient;

namespace BDD
{
    /// <summary>
    /// Interaction logic for ConnexionCompte.xaml
    /// </summary>
    public partial class ConnexionCompte : Window
    {
        private static bool unBlockCdR = false;
        private static bool cdRConnecte = false;
        private static bool clientConnecte = false;
        private static string idCdRConnecte = "";

        public static string IdCdRConnecte
        {
            get { return idCdRConnecte; }
            set { idCdRConnecte = value; }
        }

        public static bool UnBlockCdR
        {
            get { return unBlockCdR; }
            set { unBlockCdR = value; }
        }

        public static bool CdRConnecte
        {
            get { return cdRConnecte; }
            set { cdRConnecte = value; }
        }

        public static bool ClientConnecte
        {
            get { return clientConnecte; }
            set { clientConnecte = value; }
        }

        public ConnexionCompte()
        {
            InitializeComponent();
            ValiderButton2.Visibility = Visibility.Hidden;
        }

        private void SignUp(object sender, RoutedEventArgs e)
        {
            LoginPage window = new LoginPage();
            window.Show();
            this.Close();
        }

        private void Valider2Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT projet.client.idC,projet.cdr.idCdR FROM projet.client,projet.cdr WHERE email='" + EmailBox.Text + "' AND projet.client.idC = projet.cdr.idC;";     // la requete

            MySqlDataReader reader;
            reader = command.ExecuteReader();               // executer la requete (reader sera une ligne)

            string idC = "";
            string idCdR = "";
            bool estCdR = false;
            
            while (reader.Read()) // on parcourt reader ligne par ligne
            {
                idC = reader.GetString(0);
                idCdR = reader.GetString(1);
            }

            if(idC != "")
            {
                estCdR = true;
            }

            if (estCdR == true)
            {
                MessageBox.Show("Vous avez accès aux fonctions Createur de Recette !");
                unBlockCdR = true;
                cdRConnecte = true;
                clientConnecte = false;
                idCdRConnecte = idCdR;
            }
            else 
            {
                unBlockCdR = false;
                cdRConnecte = false;
                idCdRConnecte = "";
                clientConnecte = true;
            }

            connection.Close();

            ModuleClient window = new ModuleClient();
            window.Show();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleClient window = new ModuleClient();
            window.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text != "" && PswdBox.Password != "")
            {

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT email,password FROM projet.client WHERE email='" + EmailBox.Text + "';";     // la requete

                MySqlDataReader reader;
                reader = command.ExecuteReader();               // executer la requete (reader sera une ligne)

                // Manipulation du resultat

                string pswd;
                string email;
                string emailEntre = EmailBox.Text;
                string pswdEntre = PswdBox.Password;
                bool existe = false;
                bool correct = false;

                while (reader.Read()) // on parcourt reader ligne par ligne
                {
                    email = reader.GetString(0);
                    pswd = reader.GetString(1);

                    if(email == emailEntre)
                    {
                        existe = true;
                        
                        if (pswd == pswdEntre)
                        {
                            correct = true;
                            break;
                        }
                    }
                    
                }

                if (correct == false)
                {
                    MessageBox.Show("Le mot de passe ne correspond pas à cet email !");
                    PswdBox.Password = string.Empty;
                }
                else if (existe == false)
                {
                    MessageBox.Show("Il n'y a pas de compte associé à cet email !");
                    EmailBox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Connexion réussie !");
                    ValiderButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }

                connection.Close();
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
