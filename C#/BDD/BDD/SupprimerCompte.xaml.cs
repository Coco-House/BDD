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
    /// Interaction logic for SupprimerCompte.xaml
    /// </summary>
    public partial class SupprimerCompte : Window
    {
        public SupprimerCompte()
        {
            InitializeComponent();
            ValiderButton2.Visibility = Visibility.Hidden;
            JeconfirmeContent.IsEnabled = false;
        }

        private void Valider2Button_Click(object sender, RoutedEventArgs e)
        {
            if (ConnexionCompte.IdCdRConnecte != "")
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);


                // Supprimer ses recettes

                connection.Open();

                MySqlCommand commandR = connection.CreateCommand();
                commandR.CommandText = "DELETE FROM projet.recette WHERE idCdR='" + ConnexionCompte.IdCdRConnecte + "';";     // la requete

                MySqlDataReader readerR;
                readerR = commandR.ExecuteReader();               // executer la requete (reader sera une ligne)

                // Manipulation du resultat

                while (readerR.Read()) // on parcourt reader ligne par ligne
                {
                }

                connection.Close();

                // Supprimer le cdr

                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM projet.cdr WHERE idCdR='" + ConnexionCompte.IdCdRConnecte + "';";     // la requete

                MySqlDataReader reader;
                reader = command.ExecuteReader();               // executer la requete (reader sera une ligne)

                // Manipulation du resultat

                while (reader.Read()) // on parcourt reader ligne par ligne
                {
                }

                connection.Close();

                // Le supprimer de la table client

                connection.Open();

                MySqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "DELETE FROM projet.client WHERE email='" + ConnexionCompte.EmailConnecte + "';";     // la requete

                MySqlDataReader reader2;
                reader2 = command2.ExecuteReader();               // executer la requete (reader sera une ligne)

                // Manipulation du resultat

                while (reader2.Read()) // on parcourt reader ligne par ligne
                {
                }

                connection.Close();

                MessageBox.Show("Suppression réussie !");

                ConnexionCompte.UnBlockCdR = false;
                ConnexionCompte.ClientConnecte = false;
                ConnexionCompte.CdRConnecte = false;
                ConnexionCompte.IdCdRConnecte = "";
                ConnexionCompte.EmailConnecte = "";

                MainWindow.LoadDatabase();
                ModuleClient window = new ModuleClient();
                window.Show();
                this.Close();
            }
            else
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "DELETE FROM projet.client WHERE email='" + ConnexionCompte.EmailConnecte + "';";     // la requete

                MySqlDataReader reader2;
                reader2 = command2.ExecuteReader();               // executer la requete (reader sera une ligne)

                // Manipulation du resultat

                while (reader2.Read()) // on parcourt reader ligne par ligne
                {
                }

                connection.Close();

                MessageBox.Show("Suppression réussie !");

                ConnexionCompte.UnBlockCdR = false;
                ConnexionCompte.ClientConnecte = false;
                ConnexionCompte.CdRConnecte = false;
                ConnexionCompte.IdCdRConnecte = "";
                ConnexionCompte.EmailConnecte = "";

                MainWindow.LoadDatabase();
                ModuleClient window = new ModuleClient();
                window.Show();
                this.Close();
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleClient window = new ModuleClient();
            window.Show();
            this.Close();
        }

        private void ConfirmerChecked(object sender, RoutedEventArgs e)
        {
            JeconfirmeContent.IsEnabled = true;
        }

        private void ConfirmerUnchecked(object sender, RoutedEventArgs e)
        {
            JeconfirmeContent.IsEnabled = false;
            JeconfirmeContent.Text = string.Empty;
        }


        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (JeconfirmeContent.Text != "" && JeconfirmeContent.IsEnabled == true && PswdBoxVerif.Password != "" && EmailBox.Text != "" && PswdBox.Password != "")
            {
                if (EmailBox.Text != ConnexionCompte.EmailConnecte || ConnexionCompte.EmailConnecte == "")
                {
                    MessageBox.Show("L'email entré ne correspond pas à l'email de la session actuelle !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    EmailBox.Text = string.Empty;
                }
                else if (PswdBox.Password != PswdBoxVerif.Password)
                {
                    MessageBox.Show("Les 2 mots de passes sont différents !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    PswdBoxVerif.Password = string.Empty;
                }
                else if (JeconfirmeContent.Text != "Je confirme la suppression")
                {
                    MessageBox.Show("La vérification ne correspond pas ! Veuillez écrire 'Je confirme la suppression' !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    JeconfirmeContent.Text = string.Empty;
                }
                else
                {
                    string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT password FROM projet.client WHERE email='" + ConnexionCompte.EmailConnecte + "';";     // la requete

                    MySqlDataReader reader;
                    reader = command.ExecuteReader();               // executer la requete (reader sera une ligne)

                    // Manipulation du resultat

                    string pswd;
                    string pswdEntre = PswdBoxVerif.Password;
                    bool correct = false;

                    while (reader.Read()) // on parcourt reader ligne par ligne
                    {
                        pswd = reader.GetString(0);

                        if (pswd == pswdEntre)
                        {
                            correct = true;
                            break;
                        }
                    }

                    connection.Close();

                    if (correct == false)
                    {
                        MessageBox.Show("Le mot de passe ne correspond pas à cet email !");
                        PswdBoxVerif.Password = string.Empty;
                        PswdBox.Password = string.Empty;
                    }
                    else
                    {
                        var result = MessageBox.Show("Attention ! Etes-vous sûr de vouloir supprimer votre compte ? Cela supprimera vos recettes ainsi que votre compte client !", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (result == MessageBoxResult.Yes)
                        {
                            ValiderButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        }
                        else
                        {
                            MessageBox.Show("L'operation a ete abondonnée.","Suppression abandonnée !", MessageBoxButton.OK,MessageBoxImage.Information);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
