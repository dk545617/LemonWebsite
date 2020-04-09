using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class Fruit
    {
        public int FruitID { get; set; }
        [Required (ErrorMessage = "The Lemon name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Lemon soil type is required")]
        public string Soil { get; set; }
        [Required(ErrorMessage = "The Lemon feature field is required")]
        public string Feature { get; set; }
        [Required(ErrorMessage = "The Lemon water amount is required")]
        public string Water { get; set; }
    }
}
