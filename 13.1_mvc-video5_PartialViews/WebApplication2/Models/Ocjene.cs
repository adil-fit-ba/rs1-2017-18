using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Ocjene
    {
        [Key]
        public int OcjeneID { get; set; }
        public int Vrijednost { get; set; }
        public string VrijednostOpisna { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public DateTime datum { get; set; }
    }
}
