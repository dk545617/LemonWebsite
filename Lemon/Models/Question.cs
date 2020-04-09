using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        [Required (ErrorMessage= "You must enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter a subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "You must enter a post")]
        public string Post { get; set; }

    }
}
