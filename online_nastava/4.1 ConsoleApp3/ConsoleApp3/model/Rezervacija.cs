using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleApp3.model
{
    public class Rezervacija
    {
        [Key]
        public int Id { get; set; }
   
        public DateTime DatumRezervacije { get; set; }
        public Klijent Klijent { get; set; }
        public int KlijentId { get; set; }
  
        [ForeignKey(nameof(SobaId))]
        public Soba SobaObjekt { get; set; }
        public int SobaId { get; set; }

    }
}
