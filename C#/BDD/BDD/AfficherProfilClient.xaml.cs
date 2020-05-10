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
    /// Interaction logic for AfficherProfilClient.xaml
    /// </summary>
    public partial class AfficherProfilClient : Window
    {
        public AfficherProfilClient()
        {
            InitializeComponent();

            photoProfilF.Visibility = Visibility.Hidden;
            photoProfilM.Visibility = Visibility.Hidden;

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT nomC,telC,adresse,DateNaissance,sexe,prenomC,idC FROM projet.client WHERE email='" + ConnexionCompte.EmailConnecte + "';";     // la requete

            MySqlDataReader reader;
            reader = command.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            char sexe = ' ';
            DateTime DateNaissance = new DateTime();

            while (reader.Read()) // on parcourt reader ligne par ligne
            {
                NomLabel.Content = reader.GetString(5) + " " + reader.GetString(0).ToUpper();
                TelephoneLabel.Content = reader.GetString(1);
                AdresseLabel.Content = reader.GetString(2);
                DateNaissance = reader.GetDateTime(3);
                DateLabel.Content = DateNaissance.Day + "/" + DateNaissance.Month + "/" + DateNaissance.Year;
                sexe = reader.GetChar(4);
                IdLabel.Content = reader.GetString(6);
            }

            EmailLabel.Content = ConnexionCompte.EmailConnecte;

            if (sexe == 'F')
            {
                photoProfilF.Visibility = Visibility.Visible;
                FonctionLabel.Content = "Cliente";
            }
            else
            {
                photoProfilM.Visibility = Visibility.Visible;
                FonctionLabel.Content = "Client";
            }

            connection.Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            ModuleClient window = new ModuleClient();
            window.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
