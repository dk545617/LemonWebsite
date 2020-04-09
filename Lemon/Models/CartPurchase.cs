using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class CartPurchase
    {
        public int CartPurchaseId { get; set; }

        public Purchase Purchase { get; set; }

        public int Quantity { get; set; }

        public string CartId { get; set; }

    }
}
