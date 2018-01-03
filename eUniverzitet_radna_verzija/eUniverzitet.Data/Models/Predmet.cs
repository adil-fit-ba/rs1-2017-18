

namespace eUniverzitet.Data.Models
{
    public class Predmet 
    {
        public int Id { get; set; }

        

        public string Naziv { get; set; }

        public float Ects { get; set; }

        public int NppId { get; set; }
        public virtual NPP Npp { get; set; }
        public int GodinaStudija { get; set; }
    }
}
