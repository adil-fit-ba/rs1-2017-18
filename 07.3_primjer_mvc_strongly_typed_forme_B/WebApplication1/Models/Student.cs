using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Student
    {
        public string password { get; set; }
        public string zanimanje { get; set; }
        public bool isDL { get; set; }
        [Key]
        public int id{ get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public Grad Grad { get; set; }
        public int GradId { get; set; }
        public string ImePrezime{ get { return ime + " " + prezime; }}


    }
}
