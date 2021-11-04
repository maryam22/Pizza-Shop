using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{
    abstract class Gerecht : IBedrag
    {

        public Gerecht(string naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;

        }

        public string Naam { get; set; }
        public decimal Prijs { get; set; }


        //Total price of Gerecht
        public decimal BerekenBedrag()
        {
            decimal bedrag = 0;
            bedrag += Prijs;
            return bedrag;
        }

        public override string ToString()
        {

            return $"Gerecht: {Naam} ({Prijs} euro)";


        }


    }
}
