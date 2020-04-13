using Lemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }

        public float CartTotal { get; set; }
    }
}
