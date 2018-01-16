using System;


namespace eUniverzitet.Data.Models
{
    public class UpisGodine
    {
        public int Id { get; set; }
        

        public DateTime? Datum4_LjetniOvjera { get; set; }
        public DateTime? Datum3_LjetniUpis { get; set; }
        public DateTime? Datum2_ZimskiOvjera { get; set; }
        public DateTime? Datum1_ZimskiUpis { get; set; }
        public int GodinaStudija { get; set; }


        public int StudiranjeId { get; set; }
        public virtual Studiranje Studiranje { get; set; }

        public int AkademskaGodinaId { get; set; }
        public virtual AkademskaGodina AkademskaGodina { get; set; }
        public float Cijena { get; set; }
    }
}
