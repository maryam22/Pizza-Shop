using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{

    public class Bestelling : IBedrag
{
        public Bestelling()
        {
        }

        public Bestelling(Klant klant, BestelGerecht bestelGerecht, Drank drank, Dessert dessert, int aantal = 1)
        {

            Drank = drank;
            Dessert = dessert;
            Klant = klant;
            Aantal = aantal;
            BestelGerecht = bestelGerecht;
        }


        public Drank Drank { get; set; }
        public Dessert  Dessert { get; set; }

        public Klant Klant { get; set; }

        public int Aantal { get; set; }
        public BestelGerecht BestelGerecht { get; set; }
        public decimal Prijs { get;  set; }

        public decimal BerekenBedrag()
        {
            var bedrag = 0m;
            if (Drank != null) bedrag += Drank.BerekenBedrag();

            if (Dessert != null) bedrag += Dessert.BerekenBedrag();

            if (BestelGerecht != null) bedrag += BestelGerecht.BerekenBedrag();


            bedrag *= Aantal;
            if (BestelGerecht != null && Dessert != null && Drank != null)
            {
                bedrag *= 0.9m;
            }

            return bedrag;

        }

        public override string ToString()
        {
            StringBuilder sa = new StringBuilder();
            //sa.Append($"Bestelling {Klant.KlantId}:{Environment.NewLine}");
            sa.Append($"Klant: {Klant.Naam}{Environment.NewLine}");
            if (BestelGerecht != null)
            {
                sa.Append($"Gerecht: {BestelGerecht}{Environment.NewLine}");
            }
            if (Drank != null)
            {
                sa.Append($"Drank: {Drank}{Environment.NewLine}");
            }
            if (Dessert != null)
            {
                sa.Append($"Dessert: {Dessert}{Environment.NewLine}");
            }
            sa.Append($"Aantal: {Aantal}{Environment.NewLine}");
            sa.Append($"bedrag van deze bestelling:{BerekenBedrag()}{Environment.NewLine}");
            sa.Append("********************************************");

            return sa.ToString();
        }



    }
}
