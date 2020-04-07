using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class ShoppingCart
    {
        public IEnumerable<Purchase> Purchases { get; set; }

        public float TotalPrices()
        {
            float total = 0;
            foreach (Purchase purchase in Purchases)
            {
                total += purchase?.Price ?? 0;
            }
            return total;

        } //end TotalPrices()
    }//end Cart Class
}// end Namespace
