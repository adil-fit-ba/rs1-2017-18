using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Ocjena
    {
        public int OcjenaID { get; set; }
        public int BrojcanaOcjena { get; set; }

        public DateTime Datum { get; set; }

        public string Napomena { get; set; }

       public  Student student { get; set; }
       [ForeignKey(nameof(student))]
       public int studentId { get; set; }
    }
}
