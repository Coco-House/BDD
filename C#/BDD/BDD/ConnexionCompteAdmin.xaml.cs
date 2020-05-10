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
    /// Interaction logic for ConnexionCompteAdmin.xaml
    /// </summary>
    public partial class ConnexionCompteAdmin : Window
    {

        private static bool adminConnecte = false;

        public static bool AdminConnecte
        {
            get { return adminConnecte; }
            set { adminConnecte = value; }
        }

        public ConnexionCompteAdmin()
        {
            InitializeComponent();
            ValiderButton2.Visibility = Visibility.Hidden;
        }


        private void Valider2Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + usernameBox.Text + ";PASSWORD=" + PswdBox.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                connection.Close();
                MessageBox.Show("Vous avez maintenant accès aux fonctionnalités Admin !", "Login Successful !", MessageBoxButton.OK, MessageBoxImage.Information);
                adminConnecte = true;
                ModuleGestion window = new ModuleGestion();
                window.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Username ou mot de passe erroné.", "Login Failed !", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleGestion window = new ModuleGestion();
            window.Show();
            adminConnecte = false;
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameBox.Text != "" && PswdBox.Password != "")
            {
                ValiderButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
