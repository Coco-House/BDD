using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Client
    {
        private string idC;
        private string nomC;
        private string telC;

        public Client(string idC, string nomC, string telC)
        {
            this.idC = idC;
            this.nomC = nomC;
            this.telC = telC;
        }

        public string IdC
        public string IdC
        {
            get { return this.idC; }
            set { this.idC = value; }
        }

        public string NomC
        {
            get { return this.nomC; }
            set { this.nomC = value; }
        }

        public string TelC
        {
            get { return this.telC; }
            set { this.telC = value; }
        }

        public override string ToString()
        {
            string s = "\nId Client : " + this.idC
                + "\nNom Client : " + this.nomC
                + "\nTelephone Client : " + this.telC
                + "\n";
            return s;
        }
    }
}
