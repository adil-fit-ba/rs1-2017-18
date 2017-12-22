using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class AkademskaGodina:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Opis { get; set; }
       
    }
}
