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
    /// Interaction logic for Demo3.xaml
    /// </summary>
    public partial class Demo3 : Window
    {
        public Demo3()
        {
            InitializeComponent();

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand commandR = connection.CreateCommand();
            commandR.CommandText = "SELECT count(*) FROM projet.recette;";     // la requete

            MySqlDataReader readerR;
            readerR = commandR.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            while (readerR.Read()) // on parcourt reader ligne par ligne
            {
                RecettesLabel.Content = readerR.GetString(0);
            }

            connection.Close();

        }

        private void ButtonSuivant_Click(object sender, RoutedEventArgs e)
        {
            Demo4 window = new Demo4();
            window.Show();
            this.Close();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Demo2 window = new Demo2();
            window.Show();
            this.Close();
        }
    }
}
