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
    /// Interaction logic for ConnexionCompte.xaml
    /// </summary>
    public partial class ConnexionCompte : Window
    {
        private static bool unBlockCdR = false;
        private static bool cdRConnecte = false;
        private static bool clientConnecte = false;

        public static bool UnBlockCdR
        {
            get { return unBlockCdR; }
            set { unBlockCdR = value; }
        }

        public static bool CdRConnecte
        {
            get { return cdRConnecte; }
            set { cdRConnecte = value; }
        }

        public static bool ClientConnecte
        {
            get { return clientConnecte; }
            set { clientConnecte = value; }
        }

        public ConnexionCompte()
        {
            InitializeComponent();
        }
    }
}
