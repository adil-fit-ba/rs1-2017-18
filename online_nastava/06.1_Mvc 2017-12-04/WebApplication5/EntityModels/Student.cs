using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.EntityModels
{
    public class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [ForeignKey(nameof(OpstinaId))]
        public Opstina Opstina { get; set; }
        public int? OpstinaId { get; set; }
    }
}
