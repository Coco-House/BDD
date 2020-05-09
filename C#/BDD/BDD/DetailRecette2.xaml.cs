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
    /// Interaction logic for DetailRecette2.xaml
    /// </summary>
    public partial class DetailRecette2 : Window
    {
        public DetailRecette2(string idRecette)
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commandRemplir = connection.CreateCommand();
            commandRemplir.CommandText = "SELECT nomR,type,prixR,listeIngredients,quantites,descriptionR FROM projet.recette WHERE idR='" + idRecette + "'; ";

            MySqlDataReader readerRemplir;
            readerRemplir = commandRemplir.ExecuteReader();


            string listeIng = "";
            string listeQuant = "";
            while (readerRemplir.Read())
            {
                NomLabel.Content = readerRemplir.GetString(0);
                TypeLabel.Content = readerRemplir.GetString(1);
                IdLabel.Content = idRecette;
                CookLabel.Content = readerRemplir.GetInt32(2);
                EurosLabel.Content = Recette.ConvertirEnEuros(readerRemplir.GetInt32(2));

                listeIng = readerRemplir.GetString(3);
                listeQuant = readerRemplir.GetString(4);

                textDescription.Text = readerRemplir.GetString(5) + ".";


            }

            connection.Close();

            string[] ingred = listeIng.Split(';');
            string[] quantites = listeQuant.Split(';');

            List<string> unites = new List<string>();

            foreach (string nomP in ingred)
            {
                connection.Open();
                MySqlCommand commandU = connection.CreateCommand();
                commandU.CommandText = "SELECT unite FROM projet.produit WHERE nomP='" + nomP + "'; ";

                MySqlDataReader readerU;
                readerU = commandU.ExecuteReader();

                while (readerU.Read())
                {
                    unites.Add(readerU.GetString(0));
                }
                connection.Close();
            }


            for (int j = 0; j < ingred.Length; j++)
            {
                textIngredients.Text += ingred[j] + " : " + quantites[j] + " " + unites[j] + "\n";
            }

        }

    }
}
