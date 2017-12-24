using System;
using System.Collections.Generic;
using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }


        public DateTime DatumRodjenja { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int? OpstinaRodjenjaId { get; set; }
        public virtual Opstina OpstinaRodjenja { get; set; }

        public int? OpstinaPrebivalistaId { get; set; }
        public virtual Opstina OpstinaPrebivalista { get; set; }

        public virtual List<Studiranje> Studiranjes { get; set; }
    }
}
