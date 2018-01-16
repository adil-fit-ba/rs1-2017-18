using System;


namespace eUniverzitet.Data.Models
{
    public class UplataStudija
    {
        public int Id { get; set; }

        

        public DateTime DatumUplate { get; set; }
        public float Iznos { get; set; }
        public string Svrha { get; set; }
        public int EvidentiranoKorisnikId { get; set; }
        public virtual Korisnik EvidentiranoKorisnik { get; set; }
        public DateTime EvidentiranoDatum { get; set; }

        public int UpisGodineId { get; set; }
        public virtual UpisGodine UpisGodine { get; set; }
    }
}
