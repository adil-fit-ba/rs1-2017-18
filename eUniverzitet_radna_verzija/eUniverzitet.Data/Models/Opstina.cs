using System.Collections.Generic;


namespace eUniverzitet.Data.Models
{
    public class Opstina
    {
        public int Id { get; set; }

        

        public string Opis { get; set; }

        public int RegijaId { get; set; }
        public virtual Regija Regija { get; set; }
    
    }
}
