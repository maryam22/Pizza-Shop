using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{

       public enum MaatType
        {
            Groote,
            Klein
        }
        public enum ExtraType
        {
            Kaas,
            Look,
            Broed
        }


        // Main course order : Main course
        public class BestelGerecht
        {
            public BestelGerecht(Gerecht gerecht, MaatType maat = MaatType.Klein, List<ExtraType> extras = null)


            {
                Gerecht = gerecht;
                Maat = maat;
                Extras = extras;
            }

            public string GetMaat()
            {
                switch (Maat)
                {
                    case MaatType.Groote:
                        return "Groote";
                    case MaatType.Klein:
                        return "Klein";
                    default:
                        throw new Exception();
                }
            }


            public Gerecht Gerecht { get; }
            public MaatType Maat { get; set; }
            public List<ExtraType> Extras { get; set; }

            public decimal BerekenBedrag()
            {
                decimal prijsME = 0;
                decimal bedrag = 0;
                if (Maat == MaatType.Groote)
                {
                    prijsME += 3m;
                }

                if (Extras?.Count > 0)
                {

                    prijsME += Extras.Count * 1m;
                }

                bedrag = Gerecht.Prijs + prijsME;

                return bedrag;

            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Gerecht.ToString());
                sb.Append($" ({GetMaat()}) ");
                for (int i = 0; i < Extras?.Count; i++)
                {

                    sb.Append($"{Extras[i]} ");

                }
                sb.Append($"(bedrag:{BerekenBedrag()} euro)");

                return $"{sb}";

            }

        }

}
