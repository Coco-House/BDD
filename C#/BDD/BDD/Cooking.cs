using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Cooking
    {
        private string idCooking;

        public Cooking(string idCooking)
        {
            this.idCooking = idCooking;
        }

        public string IdCooking
        {
            get { return this.idCooking; }
            set { this.idCooking = value; }
        }

        public override string ToString()
        {
            return "\nId cooking : " + this.idCooking + "\n";
        }
    }
}
