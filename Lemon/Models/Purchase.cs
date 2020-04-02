using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public string PurchaseName { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        
    }
}
