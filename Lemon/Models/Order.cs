using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }




    }
}
