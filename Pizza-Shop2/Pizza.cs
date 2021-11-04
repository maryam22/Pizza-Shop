using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{
    class Pizza : Gerecht
    {
        public Pizza(string naam, decimal prijs, List<string> onderdelen)
            : base(naam, prijs)
        {
            Onderdelen = onderdelen;
        }

        public List<string> Onderdelen { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //base.ToString();
            sb.Append(base.ToString());
            for (int i = 0; i < Onderdelen.Count; i++)
            {
                sb.Append($" {Onderdelen[i]}-");
            }

            return sb.ToString();

        }
    }
}
