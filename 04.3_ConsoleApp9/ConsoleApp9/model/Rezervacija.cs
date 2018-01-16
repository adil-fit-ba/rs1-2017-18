using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9.model
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public Soba Soba { get; set; }
        public int? SobaId { get; set; }

        public Klijent Klijent { get; set; }
        public int KlijentId { get; set; }
        public DateTime DatumRezervacije { get; set; }
    }
}
