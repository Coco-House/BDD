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
    /// Interaction logic for Demo2.xaml
    /// </summary>
    public partial class Demo2 : Window
    {
        public Demo2()
        {
            InitializeComponent();


            DataTable dataDemo2 = new DataTable("Demo 2");

            dataDemo2.Columns.Add("Nombre Créateurs de Recettes");
            dataDemo2.Columns.Add("Nom Createur de Recette");
            dataDemo2.Columns.Add("Prenom Createur de Recette");
            dataDemo2.Columns.Add("Id Createur de Recette");


            dataDemo2.Columns.Add("Nombre Commandes Total", typeof(int));
            dataDemo2.Columns.Add("Nombre de Recettes Commandées", typeof(int));


            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commande = connection.CreateCommand();
            commande.CommandText = "SELECT count(*) FROM projet.cdr;";

            MySqlDataReader reader;
            reader = commande.ExecuteReader();

            int nbCdR = -1;

            while (reader.Read())
            {
                nbCdR = reader.GetInt32(0);
            }

            connection.Close();

            connection.Open();

            MySqlCommand commandRemplir = connection.CreateCommand();
            commandRemplir.CommandText = "SELECT C.nomC,C.prenomC,CdR.idCdR FROM projet.client AS C, projet.cdr AS CdR WHERE CdR.idC = C.idC";

            MySqlDataReader readerRemplir;
            readerRemplir = commandRemplir.ExecuteReader();

            List<string> listeNomC = new List<string>();
            List<string> listePrenomC = new List<string>();
            List<string> listeidCdR = new List<string>();

            while (readerRemplir.Read())
            {
                listeNomC.Add(readerRemplir.GetString(0));
                listePrenomC.Add(readerRemplir.GetString(1));
                listeidCdR.Add(readerRemplir.GetString(2));
            }

            connection.Close();

            int compteur = 0;

            foreach(string idCdR in listeidCdR)
            {
                connection.Open();

                MySqlCommand commandRemplir2 = connection.CreateCommand();
                commandRemplir2.CommandText = "SELECT SUM(nbCommandes) FROM projet.recette WHERE idCdR = '" + idCdR + "';";

                MySqlDataReader readerRemplir2;
                readerRemplir2 = commandRemplir2.ExecuteReader();

                int nbCommandesTot = -1;

                while (readerRemplir2.Read())
                {
                    nbCommandesTot = readerRemplir2.GetInt32(0);
                }

                connection.Close();


                connection.Open();

                MySqlCommand commandRemplir3 = connection.CreateCommand();
                commandRemplir3.CommandText = "SELECT count(idR) FROM projet.recette WHERE idCdR = '"+idCdR+"' AND nbCommandes != 0;";

                MySqlDataReader readerRemplir3;
                readerRemplir3 = commandRemplir3.ExecuteReader();

                int nbRecettesCommandees = -1; // avec un nbCommandes > 0

                while (readerRemplir3.Read())
                {
                    nbRecettesCommandees = readerRemplir3.GetInt32(0);
                }

                connection.Close();

                if (compteur == 0)
                {
                    dataDemo2.Rows.Add(Convert.ToString(nbCdR), listeNomC[compteur], listePrenomC[compteur], idCdR, nbCommandesTot,nbRecettesCommandees);
                }
                else
                {
                    dataDemo2.Rows.Add(" ", listeNomC[compteur], listePrenomC[compteur], idCdR, nbCommandesTot,nbRecettesCommandees);
                }
                compteur++;
            }

            dataDemo2.DefaultView.Sort = "Nombre Créateurs de Recettes desc";
            TableDonnees.ItemsSource = dataDemo2.DefaultView;
        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            Demo1 window = new Demo1();
            window.Show();
            this.Close();
        }

        private void SuivantButton_Click(object sender, RoutedEventArgs e)
        {
            Demo3 window = new Demo3();
            window.Show();
            this.Close();
        }
    }
}
