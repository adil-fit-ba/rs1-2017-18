namespace eUniverzitet.Data.Models
{
    public class IspitniRok
    {
        public int Id { get; set; }

        

        public string Opis { get; set; }

        public int AkademskaGodinaId { get; set; }
        public virtual AkademskaGodina AkademskaGodina { get; set; }
    }
}
