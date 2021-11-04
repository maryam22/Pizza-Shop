using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{

    class WarmDrank : Drank
    {


        public WarmDrank(DrankType naam)
               : base(naam)

        {
            Prijs = 2.5m;
            switch (Naam)
            {
                case DrankType.Koffie:
                case DrankType.Thee:
                    Naam = naam;
                    break;

                default:
                    throw new Exception($"Onbekende warm drink naam {naam}");
            }
        }

        public override decimal Prijs { get; }




        public override string ToString()
        {

            return base.ToString();
        }

    }
}
