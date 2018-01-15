using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Grad
    {
        [Key]
        public int GradID { get; set; }
        public string Naziv { get; set; }
    }
}
