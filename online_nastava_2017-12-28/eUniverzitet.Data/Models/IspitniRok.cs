using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class IspitniRok:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Opis { get; set; }

        public int AkademskaGodinaId { get; set; }
        public virtual AkademskaGodina AkademskaGodina { get; set; }
    }
}
