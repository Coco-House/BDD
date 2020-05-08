using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Recette
    {
        private string idR;
        private string nomR;
        private string type;
        private string listeIngredients;
        private string[] listeIdProduits;
        private string quantites;
        private string descriptionR;
        private int prixR;
        private int remunerationCdR;
        private string idGratification;
        private int nbPointsCook;
        private int nbCommandes;
        private string idCdR;

        public Recette(string idR, string nomR,string type,string listeIngredients, string qtes, string descriptionR, int prixR, int remunerationCdR, int nbCommandes, string idGrat, int nbPoints, string idCdR)
        {
            this.idR = idR;
            this.nomR = nomR;
            if((type.Split(' ')).Length == 1)
            {
                this.type = type;
            }

            this.listeIngredients = listeIngredients;
            listeIdProduits=listeIngredients.Split(';');
            this.quantites = qtes;

            if(descriptionR.Length <= 256)
            {
                this.descriptionR = descriptionR;
            }
            if(prixR >= 10 && prixR <= 40)
            {
                this.prixR = prixR;
            }
            this.nbCommandes = nbCommandes;

            this.remunerationCdR = remunerationCdR;
            this.idGratification = idGrat;
            this.nbPointsCook = nbPoints;
            this.idCdR = idCdR;
        }

        public string Quantites
        {
            get { return this.quantites; }
            set { this.quantites = value; }
        }
        public int NbCommandes
        {
            get { return this.nbCommandes; }
            set { this.nbCommandes = value; }
        }

        public string IdR
        {
            get { return this.idR; }
            set { this.idR = value; }
        }
        public string NomR
        {
            get { return this.nomR; }
            set { this.nomR = value; }
        }

        public string ListeIngredients
        {
            get { return this.listeIngredients; }
            set { this.listeIngredients = value; }
        }

        public string[] ListeIdProduits
        {
            get { return this.listeIdProduits; }
            set { this.listeIdProduits = value; }
        }

        public string DescriptionR
        {
            get { return this.descriptionR; }
            set { this.descriptionR = value; }
        }

        public int PrixR
        {
            get { return this.prixR; }
            set { this.prixR = value; }
        }

        public int RemunerationCdR
        {
            get { return this.remunerationCdR; }
            set { this.remunerationCdR = value; }
        }

        public string IdCdR
        {
            get { return this.idCdR; }
            set { this.idCdR = value; }
        }


        public string IdGratification
        {
            get { return this.idGratification; }
            set { this.idGratification = value; }
        }

        public int NbPointsCook
        {
            get { return this.nbPointsCook; }
            set { this.nbPointsCook = value; }
        }

        public override string ToString()
        {
            string s =
                "\nId Recette : " + this.idR
                + "\nNom : " + this.nomR
                + "\nListe Ingredients : \n";
            foreach (string p in this.listeIdProduits)
            {
                s += p + "\n";
            }

            s += "\nDescription : " + this.descriptionR
                + "\nPrix : " + this.prixR + " cook"
                + "\nRemuneration : " + this.remunerationCdR + " cook"
                + "\nId Gratification : " + this.idGratification
                + "\nNombre de Points : " + this.nbPointsCook + " cook"
                + "\nId Createur de Recette : " + this.IdCdR + "\n";
            return s;
        }

        public static double ConvertirEnEuros(int cook)
        {
            double taux = 0.5; // 1 cook = 0.5 euros
            return cook * taux;
        }

        public static int ConvertirEnCook(double euros)
        {
            int taux = 2; // 1 euros = 2 cook
            return Convert.ToInt32(euros * taux);
        }

    }
}
