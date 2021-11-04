using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{

    public enum DessertType
    {
        Tramisu,
        Ijs,
        Cake
    }
    public class Dessert : IBedrag
    {
        public Dessert(DessertType naam,int aantal)
        {

            Naam = naam;
            Anantal = aantal;
            switch (naam)
            {
                case DessertType.Tramisu:
                case DessertType.Ijs:
                    Prijs = 3m;
                    break;
                case DessertType.Cake:
                    Prijs = 2m;
                    break;
                default:
                    throw new Exception("Onbekende dessert naam");
            }


        }


        public decimal BerekenBedrag()
        {
            return Prijs;
        }

        public DessertType Naam { get; private set; }
        public int Anantal { get;  set; }
        public decimal Prijs { get; }

        public override String ToString()
        {

            return $"{Naam} ({Prijs} euro)";
        }

    }
}
