

namespace eUniverzitet.Data.Models
{
    public class IzvodjenjePredmeta 
    {
        public int Id { get; set; }

        

        public int AkademskaGodinaId { get; set; }
        public virtual AkademskaGodina AkademskaGodina { get; set; }

        public int PredmetId { get; set; }
        public virtual Predmet Predmet { get; set; }
    }
}
