using Lemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }

        public float CartTotal { get; set; }
    }
}
