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
    /// Interaction logic for SupprimerCompteAdmin.xaml
    /// </summary>
    public partial class SupprimerCompteAdmin : Window
    {
        public SupprimerCompteAdmin()
        {
            InitializeComponent();
            ValiderButton2.Visibility = Visibility.Hidden;

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commandIdC = connection.CreateCommand();
            commandIdC.CommandText = "SELECT idCdR FROM projet.cdr;";     // la requete

            MySqlDataReader readerIdC;
            readerIdC = commandIdC.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            while (readerIdC.Read()) // on parcourt reader ligne par ligne
            {
                IdComboBox.Items.Add(readerIdC.GetString(0));
            }

            connection.Close();
        }

        private void Valider2Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);


            // Supprimer ses recettes

            connection.Open();

            MySqlCommand commandR = connection.CreateCommand();
            commandR.CommandText = "DELETE FROM projet.recette WHERE idCdR='" + IdComboBox.SelectedItem.ToString() + "';";     // la requete

            MySqlDataReader readerR;
            readerR = commandR.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            while (readerR.Read()) // on parcourt reader ligne par ligne
            {
            }

            connection.Close();

            connection.Open();

            MySqlCommand commandIdC = connection.CreateCommand();
            commandIdC.CommandText = "SELECT idC FROM projet.cdr WHERE idCdR='" + IdComboBox.SelectedItem.ToString() + "';";     // la requete

            MySqlDataReader readerIdC;
            readerIdC = commandIdC.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            string idC = "";

            while (readerIdC.Read()) // on parcourt reader ligne par ligne
            {
                idC = readerIdC.GetString(0);
            }

            connection.Close();


            // Supprimer le cdr

            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM projet.cdr WHERE idCdR='" + IdComboBox.SelectedItem.ToString() + "';";     // la requete

            MySqlDataReader reader;
            reader = command.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            while (reader.Read()) // on parcourt reader ligne par ligne
            {
            }

            connection.Close();

            if (Non.IsChecked == true)
            {
                // Le supprimer de la table client

                connection.Open();

                MySqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "DELETE FROM projet.client WHERE idC='" + idC + "';";     // la requete

                MySqlDataReader reader2;
                reader2 = command2.ExecuteReader();               // executer la requete (reader sera une ligne)

                // Manipulation du resultat

                while (reader2.Read()) // on parcourt reader ligne par ligne
                {
                }

                connection.Close();
            }


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
            if ((Oui.IsChecked == true || Non.IsChecked == true) && IdComboBox.SelectedIndex != -1 && PswdBoxVerif.Password != "" && UsernameBox.Text != "" && PswdBox.Password != "")
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
                        string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + UsernameBox.Text + ";PASSWORD=" + PswdBoxVerif.Password;

                        MySqlConnection connection = new MySqlConnection(connectionString);
                        connection.Open();
                        connection.Close();

                        var result = MessageBox.Show("Attention ! Etes-vous sûr de vouloir supprimer le CdR " + IdComboBox.SelectedItem.ToString() + " !", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

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
                        UsernameBox.Text = string.Empty;
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

        private void OuiChecked(object sender, RoutedEventArgs e)
        {
            Non.IsChecked = false;
        }
        private void OuiUnchecked(object sender, RoutedEventArgs e)
        {
            Non.IsChecked = true;
        }

        private void NonChecked(object sender, RoutedEventArgs e)
        {
            Oui.IsChecked = false;
        }
        private void NonUnchecked(object sender, RoutedEventArgs e)
        {
            Oui.IsChecked = true;
        }
    }
}
