using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Fournisseur
    {
        private string idF;
        private string nomF;
        private string telF;

        public Fournisseur(string idF, string nomF, string telF)
        {
            this.idF = idF;
            this.nomF = nomF;
            this.telF = telF;
        }

        public string IdF
        {
            get { return this.idF; }
            set { this.idF = value; }
        }

        public string NomF
        {
            get { return this.nomF; }
            set { this.nomF = value; }
        }

        public string TelF
        {
            get { return this.telF; }
            set { this.telF = value; }
        }

        public override string ToString()
        {
            string s = "\nId Fournisseur : " + this.idF
                + "\nNom Fournisseur : " + this.nomF
                + "\nTelephone Fournisseur : " + this.telF
                + "\n";
            return s;
        }
    }
}
