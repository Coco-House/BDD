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
using MySql.Data.MySqlClient;

namespace BDD
{
    /// <summary>
    /// Interaction logic for Demo4.xaml
    /// </summary>
    public partial class Demo4 : Window
    {
        public Demo4()
        {
            InitializeComponent();

            DataTable dataDemo4 = new DataTable("Demo 4");

            dataDemo4.Columns.Add("Nom Produit");
            dataDemo4.Columns.Add("Catégorie Produit");
            dataDemo4.Columns.Add("Unité");
            dataDemo4.Columns.Add("Stock Min", typeof(int));
            dataDemo4.Columns.Add("Stock Actuel", typeof(int));
            dataDemo4.Columns.Add("Stock Max",typeof(int));
            dataDemo4.Columns.Add("Id Fournisseur");

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commande = connection.CreateCommand();
            commande.CommandText = "SELECT * FROM projet.produit WHERE stockActuel <= 2 * stockMin;";

            MySqlDataReader reader;
            reader = commande.ExecuteReader();


            while (reader.Read())
            {
                dataDemo4.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(4), reader.GetInt32(3), reader.GetInt32(5), reader.GetString(6));
            }

            connection.Close();


            dataDemo4.DefaultView.Sort = "Nom Produit asc";
            TableDonnees.ItemsSource = dataDemo4.DefaultView;
        }

        private void SuivantButton_Click(object sender, RoutedEventArgs e)
        {
            Demo5 window = new Demo5();
            window.Show();
            this.Close();
        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            Demo3 window = new Demo3();
            window.Show();
            this.Close();
        }
    }
}
