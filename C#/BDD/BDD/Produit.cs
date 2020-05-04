using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Produit
    {
        private string nomP;
        private string categorieP;
        private string unite;
        private int stockActuel;
        private int stockMin;
        private int stockMax;
        private string idF;

        public Produit(string nomP, string categorieP, string unite, int stockActuel, int stockMin, int stockMax, string idF)
        {
            this.nomP = nomP;
            this.categorieP = categorieP;
            this.unite = unite;
            this.stockActuel = stockActuel;
            this.stockMax = stockMax;
            this.stockMin = stockMin;
            this.idF = idF;
        }

        public string NomP
        {
            get { return this.nomP; }
            set { this.nomP = value; }
        }

        public string CategorieP
        {
            get { return this.categorieP; }
            set { this.categorieP = value; }
        }

        public string Unite
        {
            get { return this.unite; }
            set { this.unite = value; }
        }

        public int StockActuel
        {
            get { return this.stockActuel; }
            set { this.stockActuel = value; }
        }

        public int StockMin
        {
            get { return this.stockMin; }
            set { this.stockMin = value; }
        }

        public int StockMax
        {
            get { return this.stockMax; }
            set { this.stockMax = value; }
        }

        public string IdF
        {
            get { return this.idF; }
            set { this.idF = value; }
        }


        public override string ToString()
        {
            string s = "\nNom Produit : " + this.nomP
                + "\nCategorie : " + this.categorieP
                + "\nStock Actuel : " + this.stockActuel + " "+this.unite
                + "\nStock Max : " + this.stockMax + " " + this.unite
                + "\nStock Min : " + this.stockMin + " " + this.unite
                + "\nId Fournisseur : " + this.idF
                + "\n";
            return s;
        }
    }
}
