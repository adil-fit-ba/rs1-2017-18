using System;
using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class SlusaPredmet:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int IzvodjenjePredmetaId { get; set; }
        public virtual IzvodjenjePredmeta IzvodjenjePredmeta { get; set; }

        public int UpisGodineId { get; set; }
        public virtual UpisGodine UpisGodine { get; set; }

        public int? FinalnaOcjena { get; set; }
        public DateTime? DatumOcjene { get; set; }

        public bool Priznato { get; set; }
    }
}
