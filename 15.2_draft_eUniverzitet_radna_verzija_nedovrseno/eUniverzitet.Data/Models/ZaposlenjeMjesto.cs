

namespace eUniverzitet.Data.Models
{
    public enum ZaposlenjeNacin
    {
        OsnovnoRadnoMjesto,
        DodatnaFunkcija
    }
    public class ZaposlenjeMjesto 
    {
        public int Id { get; set; }
        
        public string Naziv { get; set; }

        public ZaposlenjeNacin ZaposlenjeNacin { get; set; }
}
}