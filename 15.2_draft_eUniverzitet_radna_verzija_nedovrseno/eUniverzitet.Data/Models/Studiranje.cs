using System;


namespace eUniverzitet.Data.Models
{

    public enum StudentiranjeStatus
    {
        Aktivan,
        Diplomirao,
        IspisaoSe
    }
    public class Studiranje 
    {
        public int Id { get; set; }

        

        public string BrojIndeksa { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int NppId { get; set; }
        public virtual NPP Npp { get; set; }

        public StudentiranjeStatus StudentiranjeStatus { get; set; }
        public DateTime UgovorPocetak { get; set; }
        public DateTime? UgovorKraj { get; set; }
    }
}
