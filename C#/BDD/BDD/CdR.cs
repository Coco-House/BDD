using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class CdR :Client
    {
        private string idCdR;
        private int cook;

        public CdR(string idC, char sexe, string nomC, string prenomC, string DateN, int age, string adresse, string email, string password, string telC,string idCdR, int cook):base(idC, sexe, nomC, prenomC, DateN, age, adresse, email, password,telC)
        {
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

        public override string ToString()
        {
            string s = base.ToString();
            s +="\nId Createur de Recette : " + this.idCdR
                + "\nNombre de Cook : " + this.cook
                + "\n";
            return s;
        }
    }
}
