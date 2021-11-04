using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{
    public class Pasta : Gerecht
    {
        public Pasta(string naam, decimal prijs, string omschrijving)
               : base(naam, prijs)
        {
            Omschrijving = omschrijving;
        }

        public string Omschrijving { get; set; }
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(Omschrijving);
            return sb.ToString();
        }
    }
}
