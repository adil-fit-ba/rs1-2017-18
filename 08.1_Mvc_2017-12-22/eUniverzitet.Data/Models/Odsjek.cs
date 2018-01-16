using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class Odsjek:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }

        public virtual Fakultet Fakultet { get; set; }
        public int FakultetId { get; set; }
    }
}
