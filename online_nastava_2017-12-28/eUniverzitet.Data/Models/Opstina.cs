using System.Collections.Generic;
using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class Opstina:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Opis { get; set; }

        public int RegijaId { get; set; }
        public virtual Regija Regija { get; set; }
    
    }
}
