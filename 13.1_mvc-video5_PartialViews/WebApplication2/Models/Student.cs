using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Student
    {
        [Key]
        public int SudentID { get; set; }
        public string Index { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? GradID { get; set; }
        public virtual Grad Grad { get; set; }

        public DateTime DatumRodjenja { get; set; }

    }
}
