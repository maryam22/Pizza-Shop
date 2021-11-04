using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{

    public enum DrankType
    {
        Thee,
        Koffie,
        Water,
        Limonade,
        Cocacola,

    }
    public abstract class Drank : IBedrag
    {
        public Drank(DrankType naam,int aantal)
        {

            Naam = naam;
            Aantal = aantal;
        }


        public abstract decimal Prijs { get; }

        public DrankType Naam { get; protected set; }
        public int Aantal { get; protected set; }

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
