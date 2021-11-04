using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{

    enum DrankType
    {
        Thee,
        Koffie,
        Water,
        Limonade,
        Cocacola,

    }
    abstract class Drank : IBedrag
    {
        public Drank(DrankType naam)
        {

            Naam = naam;
        }


        public abstract decimal Prijs { get; }

        public DrankType Naam { get; protected set; }

        public decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {

            return $"{Naam} Prijs: ({Prijs} euro)";
        }
    }
}
