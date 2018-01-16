

namespace eUniverzitet.Data.Models
{
    public class NPP
    {
        public int Id { get; set; }
        
        public string Naziv { get; set; }
        public int AkademskaGodinaId { get; set; }
        public virtual AkademskaGodina AkademskaGodina { get; set; }

        public int FakultetId { get; set; }
        public virtual Fakultet Fakultet { get; set; }

        public int? OdsjekId { get; set; }
        public virtual Odsjek Odsjek { get; set; }
    }
}
