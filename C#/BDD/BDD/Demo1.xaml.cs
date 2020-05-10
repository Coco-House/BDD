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
    /// Interaction logic for Demo1.xaml
    /// </summary>
    public partial class Demo1 : Window
    {
        public Demo1()
        {
            InitializeComponent();

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand commandR = connection.CreateCommand();
            commandR.CommandText = "SELECT count(*) FROM projet.client;";     // la requete

            MySqlDataReader readerR;
            readerR = commandR.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            while (readerR.Read()) // on parcourt reader ligne par ligne
            {
                ClientLabel.Content = readerR.GetString(0);
            }

            connection.Close();

            connection.Open();

            MySqlCommand commandR2 = connection.CreateCommand();
            commandR2.CommandText = "SELECT count(*) FROM projet.cdr;";     // la requete

            MySqlDataReader readerR2;
            readerR2 = commandR2.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            while (readerR2.Read()) // on parcourt reader ligne par ligne
            {
                CdRLabel.Content = readerR2.GetString(0);
            }

            connection.Close();
        }


        private void ButtonSuivant_Click(object sender, RoutedEventArgs e)
        {
            Demo2 window = new Demo2();
            window.Show();
            this.Close();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            PageD_accueil window = new PageD_accueil();
            window.Show();
            this.Close();
        }
    }
}
