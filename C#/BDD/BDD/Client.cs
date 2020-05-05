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
        private char sexe;
        private string nomC;
        private string prenomC;
        private string dateNaissance; // YYYY-MM-DD
        private int age;
        private string adresse;
        private string email;
        private string telC;

        public Client(string idC, char sexe, string nomC, string prenomC, string DateN, int age, string adresse, string email, string telC)
        {
            this.idC = idC;
            this.sexe = sexe;
            this.nomC = nomC;
            this.prenomC = prenomC;
            this.dateNaissance = DateN;
            this.age = age;
            this.adresse = adresse;
            this.email = email;
            this.telC = telC;
        }

        public string IdC
        {
            get { return this.idC; }
            set { this.idC = value; }
        }

        public char Sexe
        {
            get { return this.sexe; }
            set { this.sexe = value; }
        }

        public string NomC
        {
            get { return this.nomC; }
            set { this.nomC = value; }
        }

        public string PrenomC
        {
            get { return this.prenomC; }
            set { this.prenomC = value; }
        }

        public string DateNaissance
        {
            get { return this.dateNaissance; }
            set { this.dateNaissance = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
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
                + "\nPrenom Client : " + this.prenomC
                + "\nSexe : " + this.sexe
                + "\nDate de Naissance : " + this.dateNaissance
                + "\nAge : " + this.age
                + "\nAdresse : " + this.adresse
                + "\nEmail : " + this.email
                + "\nTelephone Client : " + this.telC
                + "\n";
            return s;
        }
    }
}
