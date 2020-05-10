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
    /// Interaction logic for TableauBord.xaml
    /// </summary>
    public partial class TableauBord : Window
    {
        private static List<string> listeIdRComboBoxOr = new List<string>();
        private static List<string> listeIdRComboBoxTop = new List<string>();

        public TableauBord()
        {
            InitializeComponent();

            listeIdRComboBoxOr.Clear();
            listeIdRComboBoxTop.Clear();

            CdROrLabel.Visibility = Visibility.Hidden;
            CdRSemaineLabel.Visibility = Visibility.Hidden;
            Top5Label.Visibility = Visibility.Hidden;

            OrRectangle.Visibility = Visibility.Hidden;
            TopCdRRectangle.Visibility = Visibility.Hidden;
            Top5Rectangle.Visibility = Visibility.Hidden;

            TableVide.Visibility = Visibility.Visible;
            CdROrTable.Visibility = Visibility.Hidden;
            top5RecettesTable.Visibility = Visibility.Hidden;
            topCdRSemainTable.Visibility = Visibility.Hidden;

            // Table CdR d'Or

            DataTable dataCdROr = new DataTable("CdR d'Or");

            dataCdROr.Columns.Add("Id Createur de Recette");
            dataCdROr.Columns.Add("Nom Createur de Recette");
            dataCdROr.Columns.Add("Prenom Createur de Recette");
            dataCdROr.Columns.Add("Email Createur de Recette");

            dataCdROr.Columns.Add("Id Recette");
            dataCdROr.Columns.Add("Nombre Commandes",typeof(int));
            dataCdROr.Columns.Add("Nom Recette");
            dataCdROr.Columns.Add("Type");
            dataCdROr.Columns.Add("Prix (Cook)",typeof(int));


            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand commandCdROr = connection.CreateCommand();
            commandCdROr.CommandText = "SELECT CdR.idCdR,SUM(R.nbCommandes) AS somme FROM projet.recette AS R, projet.cdr AS CdR WHERE R.idCdR = CdR.idCdR GROUP BY idCdR ORDER BY somme Desc limit 1;";

            MySqlDataReader readerRemplirCdROr;
            readerRemplirCdROr = commandCdROr.ExecuteReader();

            string idCdROr = "";

            while (readerRemplirCdROr.Read())
            {

                idCdROr = readerRemplirCdROr.GetString(0);
            }

            connection.Close();

            connection.Open();

            MySqlCommand commandRemplir = connection.CreateCommand();
            commandRemplir.CommandText = "SELECT CdR.idCdR,C.nomC,C.prenomC,C.email,R.idR,R.nbCommandes,R.nomR,R.type,R.prixR FROM projet.recette AS R, projet.client AS C, projet.cdr AS CdR WHERE R.idCdR = CdR.idCdR AND CdR.idC = C.idC AND CdR.idCdR='" + idCdROr + "' ORDER BY R.nbCommandes Desc;";

            MySqlDataReader readerRemplir;
            readerRemplir = commandRemplir.ExecuteReader();

            int compteur = 0;
            while (readerRemplir.Read())
            {
                string idCdR = readerRemplir.GetString(0);
                string nomC = readerRemplir.GetString(1);
                string prenomC = readerRemplir.GetString(2);
                string emailC = readerRemplir.GetString(3);
                string idR = readerRemplir.GetString(4);
                int nbCommandesR = readerRemplir.GetInt32(5);
                string nomR = readerRemplir.GetString(6);
                string typeR = readerRemplir.GetString(7);
                int prixR = readerRemplir.GetInt32(8);

                listeIdRComboBoxOr.Add(idR);

                if (compteur == 0)
                {
                    dataCdROr.Rows.Add(idCdR,nomC,prenomC,emailC,idR,nbCommandesR,nomR,typeR,prixR);
                }
                else
                {
                    dataCdROr.Rows.Add(" ", " ", " ", " ", idR, nbCommandesR, nomR, typeR, prixR);
                }
                compteur++;
            }

            connection.Close();

            dataCdROr.DefaultView.Sort = "Nombre Commandes desc";
            CdROrTable.ItemsSource = dataCdROr.DefaultView;

            // Table Top 5 recette de la semaine dernière

            DataTable dataTop5 = new DataTable("Top 5 recettes de la semaine");

            dataTop5.Columns.Add("Id Recette");
            dataTop5.Columns.Add("Nombre Commandes",typeof(int));
            dataTop5.Columns.Add("Nom Recette");
            dataTop5.Columns.Add("Type");
            dataTop5.Columns.Add("Prix (Cook)", typeof(int));

            dataTop5.Columns.Add("Id Createur de Recette");
            dataTop5.Columns.Add("Nom Createur de Recette");
            dataTop5.Columns.Add("Prenom Createur de Recette");
            dataTop5.Columns.Add("Email Createur de Recette");

            MainWindow.LoadDatabaseSemainePrec();

            List<Recette> listeRecettesClassees = MainWindow.listeRecettesSemainePrec;
            listeRecettesClassees.Sort((a, b) => a.NbCommandes.CompareTo(b.NbCommandes));
            
            for(int k = 0; k < 5;k++)
            {
                Recette current = listeRecettesClassees[listeRecettesClassees.Count-1-k];
                int compt = 0;
                foreach(CdR c in MainWindow.listeCdRSemainePrec)
                {
                    if(c.IdCdR == current.IdCdR)
                    {
                        break;
                    }
                    compt++;
                }
                CdR currentCdR = MainWindow.listeCdRSemainePrec[compt];

                dataTop5.Rows.Add(current.IdR, current.NbCommandes, current.NomR, current.Type, current.PrixR, current.IdCdR,currentCdR.NomC,currentCdR.PrenomC,currentCdR.Email);
                listeIdRComboBoxTop.Add(current.IdR);
            }


            dataTop5.DefaultView.Sort = "Nombre Commandes desc";
            top5RecettesTable.ItemsSource = dataTop5.DefaultView;

            // table cdr de la semaine derniere 

            DataTable dataTopCdRSem = new DataTable("Top CdR de la semaine");

            dataTopCdRSem.Columns.Add("Id Createur de Recette");
            dataTopCdRSem.Columns.Add("Nom Createur de Recette");
            dataTopCdRSem.Columns.Add("Prenom Createur de Recette");
            dataTopCdRSem.Columns.Add("Email Createur de Recette");
            dataTopCdRSem.Columns.Add("Age Createur de Recette",typeof(int));
            dataTopCdRSem.Columns.Add("Nombre Total Commandes",typeof(int));

            List<CdR> listeCdROrdonnee = MainWindow.listeCdRSemainePrec;
            List<string> listeIdCdR = new List<string>();
            List<int> listeNbCommandes = new List<int>();

            foreach(CdR c in listeCdROrdonnee)
            {
                listeIdCdR.Add(c.IdCdR);
                listeNbCommandes.Add(0);
            }


            foreach(Recette currentRecette in MainWindow.listeRecettesSemainePrec)
            {
                int index = listeIdCdR.IndexOf(currentRecette.IdCdR);
                listeNbCommandes[index] += currentRecette.NbCommandes;
            }

            int indexCdRMax = listeNbCommandes.IndexOf(listeNbCommandes.Max());

            CdR topCdRSemaine = listeCdROrdonnee[indexCdRMax];

            dataTopCdRSem.Rows.Add(topCdRSemaine.IdCdR, topCdRSemaine.NomC, topCdRSemaine.PrenomC, topCdRSemaine.Email, topCdRSemaine.Age,listeNbCommandes[indexCdRMax]);

            dataTopCdRSem.DefaultView.Sort = "Nombre Total Commandes desc";
            topCdRSemainTable.ItemsSource = dataTopCdRSem.DefaultView;

        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            ModuleGestion window = new ModuleGestion();
            window.Show();

        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Top5RecettesCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            CdROrCheckbox.IsChecked = false;
            CdRSemaineCheckbox.IsChecked = false;


            top5RecettesTable.Visibility = Visibility.Visible;
            CdROrTable.Visibility = Visibility.Hidden;
            topCdRSemainTable.Visibility = Visibility.Hidden;


            Top5RecettesCheckbox.IsEnabled = false;
            CdROrCheckbox.IsEnabled = true;
            CdRSemaineCheckbox.IsEnabled = true;


            ComboBoxRecettes.Items.Clear();

            foreach(string idR in listeIdRComboBoxTop)
            {
                ComboBoxRecettes.Items.Add(idR);
            }

            CdROrLabel.Visibility = Visibility.Hidden;
            CdRSemaineLabel.Visibility = Visibility.Hidden;
            Top5Label.Visibility = Visibility.Visible;


            OrRectangle.Visibility = Visibility.Hidden;
            TopCdRRectangle.Visibility = Visibility.Hidden;
            Top5Rectangle.Visibility = Visibility.Visible;
        }

        private void CdROrCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            Top5RecettesCheckbox.IsChecked = false;
            CdRSemaineCheckbox.IsChecked = false;


            top5RecettesTable.Visibility = Visibility.Hidden;
            CdROrTable.Visibility = Visibility.Visible;
            topCdRSemainTable.Visibility = Visibility.Hidden;


            Top5RecettesCheckbox.IsEnabled = true;
            CdROrCheckbox.IsEnabled = false;
            CdRSemaineCheckbox.IsEnabled = true;


            ComboBoxRecettes.Items.Clear(); 
            
            foreach (string idR in listeIdRComboBoxOr)
            {
                ComboBoxRecettes.Items.Add(idR);
            }

            CdROrLabel.Visibility = Visibility.Visible;
            CdRSemaineLabel.Visibility = Visibility.Hidden;
            Top5Label.Visibility = Visibility.Hidden;


            OrRectangle.Visibility = Visibility.Visible;
            TopCdRRectangle.Visibility = Visibility.Hidden;
            Top5Rectangle.Visibility = Visibility.Hidden;
        }

        private void CdRSemaineCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            CdROrCheckbox.IsChecked = false;
            Top5RecettesCheckbox.IsChecked = false;


            top5RecettesTable.Visibility = Visibility.Hidden;
            CdROrTable.Visibility = Visibility.Hidden;
            topCdRSemainTable.Visibility = Visibility.Visible;


            Top5RecettesCheckbox.IsEnabled = true;
            CdROrCheckbox.IsEnabled = true;
            CdRSemaineCheckbox.IsEnabled = false;


            ComboBoxRecettes.Items.Clear();

            CdROrLabel.Visibility = Visibility.Hidden;
            CdRSemaineLabel.Visibility = Visibility.Visible;
            Top5Label.Visibility = Visibility.Hidden;


            OrRectangle.Visibility = Visibility.Hidden;
            TopCdRRectangle.Visibility = Visibility.Visible;
            Top5Rectangle.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxRecettes.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir une recette avant de cliquer !", "Erreur!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DetailRecette2 window = new DetailRecette2(ComboBoxRecettes.SelectedItem.ToString());
                window.Show();
            }
        }
    }
}
