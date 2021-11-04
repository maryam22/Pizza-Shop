using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{
    class Klant
    {
        public Klant(int klantId, string naam)
        {
            Naam = naam;
            KlantId = klantId;
        }

        public string Naam { get; set; }
        public int KlantId { get; set; }

    }
}
