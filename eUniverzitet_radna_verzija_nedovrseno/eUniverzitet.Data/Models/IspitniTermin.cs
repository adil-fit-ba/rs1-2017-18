using System;


namespace eUniverzitet.Data.Models
{
    public class IspitniTermin
    {
        public int Id { get; set; }

        

        public int IspitniRokId { get; set; }
        public virtual IspitniRok IspitniRok { get; set; }

        public int IzvodjenjePredmetaId { get; set; }
        public virtual IzvodjenjePredmeta IzvodjenjePredmeta { get; set; }

        public DateTime VrijemeIspita { get; set; }
        public string MjestoIspita { get; set; }
    }
}
