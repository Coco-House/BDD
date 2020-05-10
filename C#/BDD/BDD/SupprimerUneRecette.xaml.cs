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
    /// Interaction logic for SupprimerUneRecette.xaml
    /// </summary>
    public partial class SupprimerUneRecette : Window
    {
        public SupprimerUneRecette()
        {
            InitializeComponent();

            if (ConnexionCompteAdmin.AdminConnecte == true)
            {
                EmailLabel.Visibility = Visibility.Hidden;
                RectangleEmail.Visibility = Visibility.Hidden;

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand commandR = connection.CreateCommand();
                commandR.CommandText = "SELECT idR FROM projet.recette;";     // la requete

                MySqlDataReader readerR;
                readerR = commandR.ExecuteReader();               // executer la requete (reader sera une ligne)

                // Manipulation du resultat

                while (readerR.Read()) // on parcourt reader ligne par ligne
                {
                    ComboboxRecettes.Items.Add(readerR.GetString(0));
                }

                connection.Close();


            }
            else if (ConnexionCompte.CdRConnecte == true)
            {
                UsernameLabel.Visibility = Visibility.Hidden;
                RectangleUsername.Visibility = Visibility.Hidden;


                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand commandR = connection.CreateCommand();
                commandR.CommandText = "SELECT idR FROM projet.recette WHERE idCdR='" + ConnexionCompte.IdCdRConnecte + "';";     // la requete

                MySqlDataReader readerR;
                readerR = commandR.ExecuteReader();               // executer la requete (reader sera une ligne)

                // Manipulation du resultat

                while (readerR.Read()) // on parcourt reader ligne par ligne
                {
                    ComboboxRecettes.Items.Add(readerR.GetString(0));
                }

                connection.Close();
            }

            ValiderButton2.Visibility = Visibility.Hidden;
        }

        private void Valider2Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand commandR = connection.CreateCommand();
            commandR.CommandText = "DELETE FROM projet.recette WHERE idR='" + ComboboxRecettes.SelectedItem.ToString() + "';";     // la requete

            MySqlDataReader readerR;
            readerR = commandR.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            while (readerR.Read()) // on parcourt reader ligne par ligne
            {
            }

            connection.Close();
            
            MessageBox.Show("Suppression réussie !");

            MainWindow.LoadDatabase();

            ModuleGestion window = new ModuleGestion();
            window.Show();
            this.Close();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleGestion window = new ModuleGestion();
            window.Show();
            this.Close();
        }



        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PswdBoxVerif.Password != "" && EmailBox.Text != "" && PswdBox.Password != "" && ComboboxRecettes.SelectedIndex != -1)
            {
                if (ConnexionCompte.CdRConnecte == true)
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
                            var result = MessageBox.Show("Attention ! Etes-vous sûr de vouloir supprimer la recette " + ComboboxRecettes.SelectedItem.ToString() + " !", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (result == MessageBoxResult.Yes)
                            {
                                ValiderButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                            }
                            else
                            {
                                MessageBox.Show("L'operation a ete abondonnée.", "Suppression abandonnée !", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
                else if (ConnexionCompteAdmin.AdminConnecte == true)
                {
                    if (PswdBox.Password != PswdBoxVerif.Password)
                    {
                        MessageBox.Show("Les 2 mots de passes sont différents !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                        PswdBoxVerif.Password = string.Empty;
                    }
                    else
                    {
                        try
                        {
                            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + EmailBox.Text + ";PASSWORD=" + PswdBoxVerif.Password;

                            MySqlConnection connection = new MySqlConnection(connectionString);
                            connection.Open();
                            connection.Close();

                            var result = MessageBox.Show("Attention ! Etes-vous sûr de vouloir supprimer la recette " + ComboboxRecettes.SelectedItem.ToString() + " !", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (result == MessageBoxResult.Yes)
                            {
                                ValiderButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                            }
                            else
                            {
                                MessageBox.Show("L'operation a ete abondonnée.", "Suppression abandonnée !", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Le mot de passe ou le username ne correspondent pas à ceux de l'admin !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                            EmailBox.Text = string.Empty;
                            PswdBox.Password = string.Empty;
                            PswdBoxVerif.Password = string.Empty;
                        }

                    }
                }

                else
                {
                    MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            if (ComboboxRecettes.SelectedIndex == -1)
            {
                MessageBox.Show("Attention ! Il faut choisir une recette !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DetailRecette2 window = new DetailRecette2(ComboboxRecettes.SelectedItem.ToString());
                window.Show();
            }
        }
    }
}

