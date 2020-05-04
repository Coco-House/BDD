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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace BDD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string username;
        private static string password;

        public MainWindow()
        {
            InitializeComponent();
            LoginButton.Visibility = Visibility.Hidden;
        }
        
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Connexion Réussie ! Vous pouvez maintenant accéder à l'application !", "Login Successful ! ", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Valider2Button_Click(object sender, RoutedEventArgs e)
        {
            if (IDBox.Text != "" && PswdBox.Password != "")
            {
                username = IDBox.Text;
                password = PswdBox.Password;

                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID="+username+";PASSWORD="+password;

                MySqlConnection connection = new MySqlConnection(connectionString);

                try
                { 
                    connection.Open();
                    LoginButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Username ou mot de passe erroné.", "Login Failed !", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Attention ! êtes-vous sûr de vouloir quitter ? ", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
            }
            
        }

    }
}
