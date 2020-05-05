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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();

            IDCdRBox.Visibility = Visibility.Hidden;
            IDCdRLabel.Visibility = Visibility.Hidden;
            VerifierIdCdRButton.Visibility = Visibility.Hidden;
            IDstart.Visibility = Visibility.Hidden;
            CalculAgeLabel.Visibility = Visibility.Hidden;
            Valider.Visibility = Visibility.Hidden;
        }

        private void MBox_Checked(object sender, RoutedEventArgs e)
        {
            FBox.IsChecked = false;
        }

        private void FBox_Checked(object sender, RoutedEventArgs e)
        {
            MBox.IsChecked = false;
        }

        private void Annee_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(((TextBox)sender).Text);
            }
            catch
            {
                MessageBox.Show("Vous devez entrez des chiffres.");
                AnneeBox.Text = string.Empty;
            }
        }

        private void Mois_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(((TextBox)sender).Text);
            }
            catch
            {
                MessageBox.Show("Vous devez entrez des chiffres.");
                MoisBox.Text = string.Empty;
            }
        }


        private void Jour_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(((TextBox)sender).Text);
            }
            catch
            {
                MessageBox.Show("Vous devez entrez des chiffres.");
                JourBox.Text = string.Empty;
            }
        }


        private void CalculerAge(object sender, RoutedEventArgs e)
        {
            if (AnneeBox.Text != "" && MoisBox.Text != "" && JourBox.Text != "")
            {
                DateTime res;

                if (DateTime.TryParse(AnneeBox.Text + "," + MoisBox.Text + "," + JourBox.Text, out res))
                {
                    if ((DateTime.Now.Month == Convert.ToInt32(MoisBox.Text) && DateTime.Now.Day >= Convert.ToInt32(JourBox.Text)) || (DateTime.Now.Month > Convert.ToInt32(MoisBox.Text)))
                    {
                        CalculAgeLabel.Content = DateTime.Now.Year - Convert.ToInt32(AnneeBox.Text);
                    }
                    else
                    {
                        CalculAgeLabel.Content = DateTime.Now.Year - Convert.ToInt32(AnneeBox.Text) - 1;
                    }

                    Age.Visibility = Visibility.Hidden;
                    CalculAgeLabel.Visibility = Visibility.Visible;
                    JourBox.IsEnabled = false;
                    AnneeBox.IsEnabled = false;
                    MoisBox.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Attention ! La date de naissance entrée n'existe pas ! ", "Erreur!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrez votre date de naissance avant de cliquer !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Client_Checked(object sender, RoutedEventArgs e)
        {
            CdRBox.IsChecked = false;
            IDCdRBox.Visibility = Visibility.Hidden;
            IDCdRLabel.Visibility = Visibility.Hidden;
            IDstart.Visibility = Visibility.Hidden;
            VerifierIdCdRButton.Visibility = Visibility.Hidden;

        }
        private void Client_UnChecked(object sender, RoutedEventArgs e)
        {
            CdRBox.IsChecked = true;
        }

        private void CdRBox_Checked(object sender, RoutedEventArgs e)
        {
            ClientBox.IsChecked = false;
            IDCdRBox.Visibility = Visibility.Visible;
            IDCdRLabel.Visibility = Visibility.Visible;
            IDstart.Visibility = Visibility.Visible;
            VerifierIdCdRButton.Visibility = Visibility.Visible;
        }
        private void CdRBox_UnChecked(object sender, RoutedEventArgs e)
        {
            ClientBox.IsChecked = true;
        }

        private void VerifierPassword_Click(object sender, RoutedEventArgs e)
        {
            if (PswdBox.Password != "" && PswdBoxVerif.Password != "")
            {
                if (PswdBox.Password == PswdBoxVerif.Password)
                {
                    MessageBox.Show("Les mots de passe correspondent !");
                    PswdBox.IsEnabled = false;
                    PswdBoxVerif.IsEnabled = false;
                    VerifierMDPButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Vous avez entre deux mots de passe differents !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    PswdBoxVerif.Password = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir les deux cases password avant de verifier !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void IdClient_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Length != 6)
            {
                MessageBox.Show("L'id doit contenir 6 chiffres.");
                IDClientBox.Text = string.Empty;
            }
            else
            {
                try
                {
                    Convert.ToInt32(((TextBox)sender).Text);

                    VerifierIdCButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                catch
                {
                    MessageBox.Show("Vous devez entrez des entiers.");
                    IDClientBox.Text = string.Empty;
                }
            }
        }

        private void IdCdR_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Length != 6)
            {
                MessageBox.Show("L'id doit contenir 6 chiffres.");
                IDCdRBox.Text = string.Empty;
            }
            else
            {
                try
                {
                    Convert.ToInt32(((TextBox)sender).Text);
                    VerifierIdCdRButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                catch
                {
                    MessageBox.Show("Vous devez entrez des entiers.");
                    IDCdRBox.Text = string.Empty;
                }
            }
        }


        private void VerifierIdClient_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT idC FROM projet.client";     // la requete

            MySqlDataReader reader;
            reader = command.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            string id;
            string idEntre = "C" + IDClientBox.Text;
            bool existe = false;

            while (reader.Read()) // on parcourt reader ligne par ligne
            {
                id = reader.GetString(0); // 1ere colonne

                if (idEntre == id)
                {
                    MessageBox.Show("L'Id existe deja, veuillez saisir un autre Id.");
                    IDClientBox.Text = string.Empty;
                    existe = true;
                    break;
                }

            }

            if (existe == false)
            {
                MessageBox.Show("L'Id a bien ete enregistre.");
                IDClientBox.IsEnabled = false;
                VerifierIdCButton.IsEnabled = false;
            }

            connection.Close();
        }

        private void VerifierIdCdR_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT idCdR FROM projet.cdr";     // la requete

            MySqlDataReader reader;
            reader = command.ExecuteReader();               // executer la requete (reader sera une ligne)

            // Manipulation du resultat

            string id;
            string idEntre = "CdR" + IDCdRBox.Text;
            bool existe = false;

            while (reader.Read()) // on parcourt reader ligne par ligne
            {
                id = reader.GetString(0); // 1ere colonne

                if (idEntre == id)
                {
                    MessageBox.Show("L'Id existe deja, veuillez saisir un autre Id.");
                    IDCdRBox.Text = string.Empty;
                    existe = true;
                    break;
                }

            }

            if (existe == false)
            {
                var result = MessageBox.Show("Attention ! êtes-vous sûr de vous enregistrer comme Createur de Recette ? (Pas de retour en arriere)", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("L'Id a bien ete enregistre.");
                    IDCdRBox.IsEnabled = false;
                    VerifierIdCdRButton.IsEnabled = false;
                    ClientBox.IsEnabled = false;
                    CdRBox.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("L'operation a ete abondonnee.");
                    IDCdRBox.Text = string.Empty;
                }

            }

            connection.Close();
        }

        private void Verifier_Click(object sender, RoutedEventArgs e)
        {
            if (NomBox.Text != "" && PrenomBox.Text != "" && (MBox.IsChecked == true || FBox.IsChecked == true) && JourBox.Text != "" && MoisBox.Text != "" && AnneeBox.Text != ""
                && AdresseBox.Text != "" && TelephoneBox.Text != "" && Age.Visibility == Visibility.Hidden
                && EmailBox.Text != "" && PswdBox.Password != "" && PswdBoxVerif.Password != "" && VerifierMDPButton.IsEnabled == false && IDClientBox.Text != "" && VerifierIdCButton.IsEnabled == false && IDClientBox.IsEnabled == false
                && (ClientBox.IsChecked == true || (CdRBox.IsChecked == true && IDCdRBox.Text != "" && VerifierIdCdRButton.IsEnabled == false && IDCdRBox.IsEnabled == false)))

            {
                Valider.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires et vérifier le mot de passe et le(s) id(s) !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Attention ! êtes-vous sûr de vouloir abandonner l'inscription ?", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                ModuleClient m = new ModuleClient();
                m.Show();
                this.Close();
            }
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
             try
             {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            string idC = IDClientBox.Text;
            char sexe = 'F';

            if (MBox.IsChecked == true)
            {
                sexe = 'M';
            }

            string nomC = NomBox.Text;
            string prenomC = PrenomBox.Text;
            string dateNaissance = AnneeBox.Text + "-" + MoisBox.Text + "-" + JourBox.Text;
            int age = Convert.ToInt32(CalculAgeLabel.Content);
            string adresse = AdresseBox.Text;
            string email = EmailBox.Text;
            string password = PswdBoxVerif.Password;
            string telC = TelephoneBox.Text;

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " INSERT INTO projet.client(`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES('" + idC + "','" + nomC + "','" + prenomC + "','" + dateNaissance + "'," + age + ",'" + adresse + "','" + sexe + "','" + email + "','" + password + "','" + telC + "');";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read()) { }

            connection.Close();


            if (CdRBox.IsChecked == true)
            {
                int cook = 0;
                string idCdR = IDCdRBox.Text;

                CdR newCdR = new CdR(idC, sexe, nomC, prenomC, dateNaissance, age, adresse, email, password, telC, idCdR, cook);
                MainWindow.listeCdR.Add(newCdR);

                connection.Open();
                MySqlCommand commandCdR = connection.CreateCommand();
                commandCdR.CommandText = "INSERT INTO projet.cdr(`idCdR`,`cook`,`idC`) VALUES('" + idCdR + "','" + cook + "','" + idC + "');";

                MySqlDataReader readerCdR;
                readerCdR = commandCdR.ExecuteReader();

                while (readerCdR.Read()) { }

                connection.Close();

            }
            else
            {
                Client newClient = new Client(idC, sexe, nomC, prenomC, dateNaissance, age, adresse, email, password, telC);
                MainWindow.listeClients.Add(newClient);
            }

            MessageBox.Show("Inscription reussie !", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            ConnexionCompte window = new ConnexionCompte();
            window.Show();

            this.Close();
              }
              catch
              {
                  MessageBox.Show("Inscription non reussie !", "Erreur!", MessageBoxButton.OK, MessageBoxImage.Error);
              }

        }


    }
}
