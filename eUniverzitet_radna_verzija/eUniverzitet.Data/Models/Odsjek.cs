

namespace eUniverzitet.Data.Models
{
    public class Odsjek
    {
        public int Id { get; set; }
        
        public string Naziv { get; set; }

        public virtual Fakultet Fakultet { get; set; }
        public int FakultetId { get; set; }
    }
}
