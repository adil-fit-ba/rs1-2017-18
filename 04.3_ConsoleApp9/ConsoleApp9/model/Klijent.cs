using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ConsoleApp9.atributi;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConsoleApp9.model
{
   
    public class Klijent
    {
        [Key]
        public int Id { get; set; }
      
        public string ImePrezime{ get; set; }


        public Opstina Opstina { get; set; }
        public int? OpstinaId { get; set; }


        public List<Rezervacija> Rezervacijas { get; set; }
    }
}
