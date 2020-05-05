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

namespace BDD
{
    /// <summary>
    /// Interaction logic for PageD_accueil.xaml
    /// </summary>
    public partial class PageD_accueil : Window
    {
        
        public PageD_accueil()
        {
            InitializeComponent();
        }
        

        private void Client(object sender, RoutedEventArgs e)
        {
            ModuleClient window = new ModuleClient();
            window.Show();
            this.Close();
        }

        private void CdR(object sender, RoutedEventArgs e)
        {
            if (ConnexionCompte.UnBlockCdR == false)
            {
                MessageBox.Show("Attention ! Vous n'etes pas un créateur de recette ! Vous n'avez pas accès à ces fonctions", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ConnexionCompte window = new ConnexionCompte();
                window.Show();
                this.Close();
            }
        }

        private void Gestion(object sender, RoutedEventArgs e)
        {

        }

        private void Demo(object sender, RoutedEventArgs e)
        {

        }

        

    }
}
