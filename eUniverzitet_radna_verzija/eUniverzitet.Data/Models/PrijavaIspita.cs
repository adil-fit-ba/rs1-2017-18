using System;


namespace eUniverzitet.Data.Models
{
    public class PrijavaIspita
    {
        public int Id { get; set; }

        

        public int SlusaPredmetId { get; set; }
        public virtual SlusaPredmet SlusaPredmet { get; set; }

        public int IspitniTerminId { get; set; }
        public virtual IspitniTermin IspitniTermin { get; set; }

        public DateTime PrijavaDatum { get; set; }
 
        public DateTime? OdjavaDatum { get; set; }
    }
}