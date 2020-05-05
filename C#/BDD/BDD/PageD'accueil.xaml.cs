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

        }

        private void Gestion(object sender, RoutedEventArgs e)
        {

        }

        private void Demo(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Attention ! êtes-vous sûr de vouloir quitter ? ", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
