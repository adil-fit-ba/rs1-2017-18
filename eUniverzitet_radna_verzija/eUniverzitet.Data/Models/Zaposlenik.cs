using System.Collections.Generic;


namespace eUniverzitet.Data.Models
{
    
    public class Zaposlenik
    {
        public int Id { get; set; }
        
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual List<Zaposlenje> Zaposlenja { get; set; }
    }
}