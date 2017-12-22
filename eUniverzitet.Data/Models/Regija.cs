using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class Regija:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }
    }
}
