using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class NPP:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }
        public int AkademskaGodinaId { get; set; }
        public virtual AkademskaGodina AkademskaGodina { get; set; }

        public int FakultetId { get; set; }
        public virtual Fakultet Fakultet { get; set; }

        public int? OdsjekId { get; set; }
        public virtual Odsjek Odsjek { get; set; }
    }
}
