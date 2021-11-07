using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{

    public class Frisdrank : Drank
    {

        public Frisdrank(DrankType naam,int aantal)
        : base(naam, aantal)
        {
            Prijs = 2m;
            switch (naam)
            {
                case DrankType.Water:
                case DrankType.Limonade:
                case DrankType.Cocacola:
                    Naam = naam;
                    break;
                

            }

        }

        public override decimal Prijs { get; }


        public override string ToString()
        {

            return base.ToString();
        }
    }
}
