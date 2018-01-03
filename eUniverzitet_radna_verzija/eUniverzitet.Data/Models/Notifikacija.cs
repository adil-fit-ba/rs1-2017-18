using System;


namespace eUniverzitet.Data.Models
{
    public class Notifikacija
    {
        public int Id { get; set; }

        

        public string Naslov { get; set; }
        public string Opis { get; set; }
        public DateTime Vrijeme { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }

        public bool IsRead { get; set; }
    }
}
