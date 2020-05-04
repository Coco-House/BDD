using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class CdR
    {
        private string idCdR;
        private int cook;
        private string idC;

        public CdR(string idCdR, int cook, string idC)
        {
            this.idC = idC;
            this.cook = cook;
            this.idCdR = idCdR;
        }
        public string IdCdR
        {
            get { return this.idCdR; }
            set { this.idCdR = value; }
        }

        public int Cook
        {
            get { return this.cook; }
            set { this.cook = value; }
        }

        public string IdC
        {
            get { return this.idC; }
            set { this.idC = value; }
        }

        public override string ToString()
        {
            string s = "\nId Createur de Recette : " + this.idCdR
                + "\nNombre de Cook : " + this.cook
                + "\nId Client : " + this.idC
                + "\n";
            return s;
        }
    }
}
