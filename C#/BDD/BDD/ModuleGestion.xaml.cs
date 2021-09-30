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
using System.Xml;

namespace BDD
{
    /// <summary>
    /// Interaction logic for ModuleGestion.xaml
    /// </summary>
    public partial class ModuleGestion : Window
    {

        public static bool aReapprovisionne = false;

        public ModuleGestion()
        {
            InitializeComponent();

            ReapprovisionnementButton.IsEnabled = false; /// seulement disponible en fin de semaine ! Dimanche !

            if(DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                if (aReapprovisionne == true)
                {
                    ReapprovisionnementButton.IsEnabled = false;
                }
                else
                {
                    ReapprovisionnementButton.IsEnabled = true;
                }
            }

            
           
            if(ConnexionCompte.CdRConnecte == false && ConnexionCompte.ClientConnecte==false && ConnexionCompteAdmin.AdminConnecte == false)
            {
                ConnexionAdminButton.IsEnabled = true;
                SupprimerRecetteButton.IsEnabled = false;
                RajouterProduitButton.IsEnabled = false;
                SupprimerCompteButton.IsEnabled = false;
                DeconnexionAdminButton.IsEnabled = false;
            }
            else if(ConnexionCompte.CdRConnecte == true)
            {
                ConnexionAdminButton.IsEnabled = false;
                SupprimerRecetteButton.IsEnabled = true;
                RajouterProduitButton.IsEnabled = false;
                SupprimerCompteButton.IsEnabled = false;
                DeconnexionAdminButton.IsEnabled = false;
            }
            else if(ConnexionCompte.ClientConnecte == true)
            {
                ConnexionAdminButton.IsEnabled = false;
                SupprimerRecetteButton.IsEnabled = false;
                RajouterProduitButton.IsEnabled = false;
                SupprimerCompteButton.IsEnabled = false;
                DeconnexionAdminButton.IsEnabled = false;
            }
            else if(ConnexionCompteAdmin.AdminConnecte == true)
            {
                ConnexionAdminButton.IsEnabled = false;
                SupprimerRecetteButton.IsEnabled = true;
                RajouterProduitButton.IsEnabled = true;
                SupprimerCompteButton.IsEnabled = true;
                DeconnexionAdminButton.IsEnabled = true;
            }

        }

        private void ConnexionAdmin_Click(object sender, RoutedEventArgs e)
        {
            ConnexionCompteAdmin window = new ConnexionCompteAdmin();
            window.Show();
            this.Close();
        }

        private void TableauBord_Click(object sender, RoutedEventArgs e)
        {
            TableauBord window = new TableauBord();
            window.Show();
            this.Close();
        }

        private void SupprimerRecette_Click(object sender, RoutedEventArgs e)
        {
            SupprimerUneRecette window = new SupprimerUneRecette();
            window.Show();
            this.Close();
        }

        private void RajouterProduit_Click(object sender, RoutedEventArgs e)
        {
            CreerProduitAdmin window = new CreerProduitAdmin();
            window.Show();
            this.Close();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            SupprimerCompteAdmin window = new SupprimerCompteAdmin();
            window.Show();
            this.Close();
        }

        private void DeconnexionAdmin_Click(object sender, RoutedEventArgs e)
        {
            ConnexionCompteAdmin.AdminConnecte = false;
            ConnexionAdminButton.IsEnabled = true;
            SupprimerRecetteButton.IsEnabled = false;
            RajouterProduitButton.IsEnabled = false;
            SupprimerCompteButton.IsEnabled = false;
            DeconnexionAdminButton.IsEnabled = false;
        }

        private void Reapprovisionnement_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.Now.DayOfWeek != DayOfWeek.Friday)
            {
                MessageBox.Show("Attention ! cette fonction est disponible qu'en fin de semaine ! (Dimanche) ", "Erreur!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Mettre à jour les stocks des produits non utilisés depuis 1 mois

                int indiceProd = 0;

                foreach (int nbSemaines in MainWindow.listeNbSemainesSansCommande)
                {
                    if (nbSemaines != 0 && nbSemaines % 4 == 0) // Donc 1 mois
                    {
                        MainWindow.listeProduits[indiceProd].StockMax = MainWindow.listeProduits[indiceProd].StockMax / 2;
                        MainWindow.listeProduits[indiceProd].StockMin = MainWindow.listeProduits[indiceProd].StockMin / 2;

                        if (MainWindow.listeProduits[indiceProd].StockActuel > MainWindow.listeProduits[indiceProd].StockMax)
                        {
                            MainWindow.listeProduits[indiceProd].StockActuel = MainWindow.listeProduits[indiceProd].StockMax;
                        }

                        string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                        MySqlConnection connection = new MySqlConnection(connectionString);


                        connection.Open();

                        MySqlCommand commandUpdate = connection.CreateCommand();
                        commandUpdate.CommandText = "UPDATE projet.produit SET stockActuel=stockMax/2,stockMax=stockMax/2,stockMin=stockMin/2 WHERE nomP='" + MainWindow.listeProduits[indiceProd].NomP + "';";

                        MySqlDataReader readerUpdate;
                        readerUpdate = commandUpdate.ExecuteReader();

                        while (readerUpdate.Read()) { }

                        connection.Close();
                    }

                    indiceProd++;
                }


                XmlDocument docXml = new XmlDocument();
                docXml.Load("Reapprovisionnement.xml");

                XmlElement racine = docXml.DocumentElement;
                foreach (XmlNode e1 in racine)                         // balise commande
                {
                    // e.Name --> nom de la balise fournisseur
                    if (e1.ChildNodes != null)
                    {
                        foreach (XmlNode e2 in e1)                        // les Nodes dans fournisseur
                        {
                            string idFb = "";
                            string nomPb = "";
                            int quantite = 0;
                            string uniteb = "";

                            foreach (XmlNode e3 in e2.ChildNodes)       // les attributs de chaque balise imbriquee dans la balise imbriquee dans racine
                            {
                                if (e3.Name == "#text")
                                {
                                    idFb = e3.InnerText;
                                }
                                else if (e3.Name == "nomP")
                                {
                                    nomPb = e3.InnerText;
                                }
                                else if (e3.Name == "quantiteCommander")
                                {
                                    quantite = Convert.ToInt32(e3.InnerText);
                                }
                                else if (e3.Name == "unite")
                                {
                                    uniteb = e3.InnerText;
                                }
                            }

                            if (nomPb != "" && quantite != 0)
                            {
                                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                                MySqlConnection connection = new MySqlConnection(connectionString);

                                connection.Open();

                                MySqlCommand commandUpdate = connection.CreateCommand();
                                commandUpdate.CommandText = "UPDATE projet.produit SET stockActuel=stockActuel+" + quantite + " WHERE nomP='" + nomPb + "';";

                                MySqlDataReader readerUpdate;
                                readerUpdate = commandUpdate.ExecuteReader();

                                while (readerUpdate.Read()) { }

                                connection.Close();
                            }
                        }
                    }
                }

                MainWindow.LoadDatabase();
                MainWindow.SaveDatabaseSemainePrec();
                MainWindow.LoadDatabaseSemainePrec();
               

                MessageBox.Show("Réapprovisionnement de la semaine dernière a bien été réussi !", "Success !", MessageBoxButton.OK, MessageBoxImage.Information);


                // Réapprovisionnement pour la semaine prochaine 

                XmlDocument docXml2 = new XmlDocument();

                // création de l élément racine ... qu'on ajoute au document

                XmlElement racine2 = docXml2.CreateElement("commande");
                docXml2.AppendChild(racine2);


                // création et insertion de l en-tête XML (no <=> pas de DTD associée)

                XmlDeclaration xmldecl = docXml2.CreateXmlDeclaration("1.0", "UTF-8", "no");
                docXml2.InsertBefore(xmldecl, racine2);

                string connectionString2 = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection2 = new MySqlConnection(connectionString2);

                connection2.Open();

                MySqlCommand commandUpdate2 = connection2.CreateCommand();
                commandUpdate2.CommandText = "select nomP,idF,unite,stockMax,stockActuel FROM projet.produit WHERE stockActuel<stockMin ORDER BY idF;";

                MySqlDataReader readerUpdate2;
                readerUpdate2 = commandUpdate2.ExecuteReader();

                List<string> listeIdF = new List<string>();
                List<string> listeNomP = new List<string>();
                List<string> listeUnites = new List<string>();
                List<int> listeQuantitesCommander = new List<int>();

                while (readerUpdate2.Read())
                {
                    listeIdF.Add(readerUpdate2.GetString(1));
                    listeNomP.Add(readerUpdate2.GetString(0));
                    listeUnites.Add(readerUpdate2.GetString(2));
                    listeQuantitesCommander.Add(readerUpdate2.GetInt32(3) - readerUpdate2.GetInt32(4));
                }

                connection2.Close();

                if (listeIdF.Count != 0)
                {
                    int l = 0;

                    while (l < listeIdF.Count - 1)
                    {
                        XmlElement fournisseur = docXml2.CreateElement("fournisseur");
                        racine2.AppendChild(fournisseur);

                        XmlElement idF = docXml2.CreateElement("idF");
                        idF.InnerText = listeIdF[l];
                        fournisseur.AppendChild(idF);

                        XmlElement produit = docXml2.CreateElement("produit");
                        fournisseur.AppendChild(produit);


                        XmlElement nomP = docXml2.CreateElement("nomP");
                        nomP.InnerText = listeNomP[l];
                        produit.AppendChild(nomP);

                        XmlElement quantiteCommander = docXml2.CreateElement("quantiteCommander");
                        quantiteCommander.InnerText = Convert.ToString(listeQuantitesCommander[l]);
                        produit.AppendChild(quantiteCommander);

                        XmlElement unite = docXml2.CreateElement("unite");
                        unite.InnerText = listeUnites[l];
                        produit.AppendChild(unite);

                        while (listeIdF[l + 1] == listeIdF[l])
                        {
                            l = l + 1;

                            XmlElement produit2 = docXml2.CreateElement("produit");
                            fournisseur.AppendChild(produit2);


                            XmlElement nomP2 = docXml2.CreateElement("nomP");
                            nomP2.InnerText = listeNomP[l];
                            produit2.AppendChild(nomP2);

                            XmlElement quantiteCommander2 = docXml2.CreateElement("quantiteCommander");
                            quantiteCommander2.InnerText = Convert.ToString(listeQuantitesCommander[l]);
                            produit2.AppendChild(quantiteCommander2);

                            XmlElement unite2 = docXml2.CreateElement("unite");
                            unite2.InnerText = listeUnites[l];
                            produit2.AppendChild(unite2);

                            if (l == listeIdF.Count - 1)
                            {
                                break;
                            }
                        }

                        if (l == listeIdF.Count - 2 && listeIdF[l + 1] != listeIdF[l])
                        {
                            XmlElement fournisseur3 = docXml2.CreateElement("fournisseur");
                            racine2.AppendChild(fournisseur3);

                            XmlElement idF3 = docXml2.CreateElement("idF");
                            idF3.InnerText = listeIdF[l];
                            fournisseur3.AppendChild(idF3);

                            XmlElement produit3 = docXml2.CreateElement("produit");
                            fournisseur3.AppendChild(produit3);


                            XmlElement nomP3 = docXml2.CreateElement("nomP");
                            nomP3.InnerText = listeNomP[l];
                            produit3.AppendChild(nomP3);

                            XmlElement quantiteCommander3 = docXml2.CreateElement("quantiteCommander");
                            quantiteCommander3.InnerText = Convert.ToString(listeQuantitesCommander[l]);
                            produit.AppendChild(quantiteCommander3);

                            XmlElement unite3 = docXml2.CreateElement("unite");
                            unite3.InnerText = listeUnites[l];
                            produit3.AppendChild(unite3);
                        }

                        l = l + 1;
                    }

                    // enregistrement du document XML 

                    docXml2.Save("Reapprovisionnement.xml");

                    MessageBox.Show("Fichier Reapprovisionnement.xml créé !", "Success !", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Verifications : D'apres les modifications fait dans MySQL 
                    // --> oeuf, gruyere rape et basilic doivent avoir stockActuel = stockMax
                    // --> lardon, sucre et lait doivent apparaitre dans le nouveau fichier .xml avec une quantiteCommande = 2 759 g ,95 000g et 32L respectivement

                    ReapprovisionnementButton.IsEnabled = false;
                    aReapprovisionne = true;
                }
            }
        }

        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            PageD_accueil window = new PageD_accueil();
            window.Show();
            this.Close();
        }
    }
}
