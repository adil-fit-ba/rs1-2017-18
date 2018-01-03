using System;


namespace eUniverzitet.Data.Models
{
    public class SlusaPredmet
    {
        public int Id { get; set; }

        

        public int IzvodjenjePredmetaId { get; set; }
        public virtual IzvodjenjePredmeta IzvodjenjePredmeta { get; set; }

        public int UpisGodineId { get; set; }
        public virtual UpisGodine UpisGodine { get; set; }

        public int? FinalnaOcjena { get; set; }
        public DateTime? DatumOcjene { get; set; }

        public bool Priznato { get; set; }
    }
}
