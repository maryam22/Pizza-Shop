using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{
    public class Store
    {
        public List<Bestelling> GerechtlList { get; set; }
        public List<Bestelling> BestelingList { get; set; }

        public  Store()
        {
            GerechtlList = new List<Bestelling>();
            BestelingList = new List<Bestelling>();
        }
        public decimal Checkout()
        {
            //initialize the total cost
            decimal totalCost = 0;
            foreach (var c in BestelingList)
            {
                totalCost = totalCost + c.BerekenBedrag();
            }
            BestelingList.Clear();
            return totalCost;

        }
    }
}
