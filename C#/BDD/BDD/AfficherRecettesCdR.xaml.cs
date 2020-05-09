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
using System.Data;

namespace BDD
{
    /// <summary>
    /// Interaction logic for AfficherRecettesCdR.xaml
    /// </summary>
    public partial class AfficherRecettesCdR : Window
    {
        public AfficherRecettesCdR()
        {
            InitializeComponent();

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand commandRechercheR = connection.CreateCommand();
            commandRechercheR.CommandText = "SELECT nomR AS Nom_Recette,nbCommandes AS Nombre_Commandes, idR AS Id_Recette, type,prixR AS Prix_Recette,remunerationCuisinier AS Remuneration FROM projet.recette WHERE idCdR='" + ConnexionCompte.IdCdRConnecte+"';";
            commandRechercheR.ExecuteNonQuery();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(commandRechercheR);
            DataTable dataRecettes = new DataTable("Liste Recettes du CdR");
            dataAdapter.Fill(dataRecettes);

            RecetteTable.ItemsSource = dataRecettes.DefaultView;
            dataAdapter.Update(dataRecettes);

            connection.Close();

            connection.Open();

            MySqlCommand commandRemplir = connection.CreateCommand();
            commandRemplir.CommandText = "SELECT idR FROM projet.recette WHERE idCdR='" + ConnexionCompte.IdCdRConnecte + "'; ";

            MySqlDataReader readerRemplir;
            readerRemplir = commandRemplir.ExecuteReader();



            while (readerRemplir.Read())
            {
                ListeRecettesDetail.Items.Add(readerRemplir.GetString(0));
            }
           connection.Close();

        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            ModuleCdR window = new ModuleCdR();
            window.Show();

        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            DetailRecette2 window = new DetailRecette2(ListeRecettesDetail.SelectedItem.ToString());
            window.Show();
            ListeRecettesDetail.SelectedIndex = -1;
        }
    }
}
