using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int PurchaseId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public virtual Purchase Purchase { get; set; }

        public virtual Order Order { get; set; }
        
    }
}
