﻿using System;
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
    /// Interaction logic for CreerProduitCdR.xaml
    /// </summary>
    public partial class CreerProduitCdR : Window
    {
        public CreerProduitCdR()
        {
            InitializeComponent();
            
            ValiderButton2.Visibility = Visibility.Hidden;

            MainWindow.LoadDatabase();

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand commandRemplir = connection.CreateCommand();
            commandRemplir.CommandText = "SELECT DISTINCT idF FROM projet.produit ORDER BY idF;";

            MySqlDataReader readerRemplir;
            readerRemplir = commandRemplir.ExecuteReader();


            while (readerRemplir.Read())
            {
                FournisseurComboBox.Items.Add(readerRemplir.GetString(0));
            }

            
            connection.Close();

            connection.Open();

            MySqlCommand commandRemplir2 = connection.CreateCommand();
            commandRemplir2.CommandText = "SELECT DISTINCT categorieP FROM projet.produit ORDER BY categorieP;";

            MySqlDataReader readerRemplir2;
            readerRemplir2 = commandRemplir2.ExecuteReader();


            while (readerRemplir2.Read())
            {
                if (readerRemplir2.GetString(0) != "Autre")
                {
                    categorieComboBox.Items.Add(readerRemplir2.GetString(0));
                }
                
            }

            categorieComboBox.Items.Add("Autre");

            connection.Close();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Attention ! êtes-vous sûr de vouloir abandonner la création ?", "Warning !", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Valider2Button_Click(object sender, RoutedEventArgs e)
        {
            int stockAct = 50 * Convert.ToInt32(QuantiteBox.Text);
            int stockMin = 20 * Convert.ToInt32(QuantiteBox.Text);
            int stockMax = 80*Convert.ToInt32(QuantiteBox.Text);

            Produit nouveauProd = new Produit(NomBox.Text, categorieComboBox.SelectedItem.ToString(), UniteBox.Text, stockAct, stockMin, stockMax, FournisseurComboBox.SelectedItem.ToString());

            CreerRecette.listeNomNouveauxProduits.Add(nouveauProd);
            CreerRecette.listeQuantiteNouveauxProduits.Add(QuantiteBox.Text);

            MessageBox.Show("Le produit a bien été créé !", "Success !", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void CreerButton_Click(object sender, RoutedEventArgs e)
        {
            if(NomBox.Text != "" && QuantiteBox.Text != "" && UniteBox.Text != "" && categorieComboBox.SelectedIndex != -1 && FournisseurComboBox.SelectedIndex != -1)
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=projet;UID=" + MainWindow.Username + ";PASSWORD=" + MainWindow.Password;

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand commandRemplir = connection.CreateCommand();
                commandRemplir.CommandText = "SELECT nomP FROM projet.produit WHERE nomP='" + NomBox.Text + "';";

                MySqlDataReader readerRemplir;
                readerRemplir = commandRemplir.ExecuteReader();

                string nomExiste = "";
                while (readerRemplir.Read())
                {
                    nomExiste = readerRemplir.GetString(0);
                }

                if (nomExiste != "")
                {
                    MessageBox.Show("Le produit existe déjà dans la database (sinon, changez de nom) !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    NomBox.Text = string.Empty;

                    connection.Close();
                }
                else
                {
                    bool dejaCree = false;

                    foreach(Produit p in CreerRecette.listeNomNouveauxProduits)
                    {
                        if(p.NomP == NomBox.Text)
                        {
                            MessageBox.Show("Vous avez créé un produit avec le même nom pendant cette session de création !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                            NomBox.Text = string.Empty;
                            dejaCree = true;
                            break;
                        }
                    }

                    if (dejaCree == false)
                    {
                        try
                        {
                            Convert.ToInt32(QuantiteBox.Text);
                            connection.Close();
                            ValiderButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        }
                        catch
                        {
                            MessageBox.Show("Il faut saissir des chiffres pour la quantité !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                            QuantiteBox.Text = string.Empty;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Attention ! Il faut remplir tous les champs necessaires !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            CreerRecette window = new CreerRecette();
            window.Show();
        }
    }
}
