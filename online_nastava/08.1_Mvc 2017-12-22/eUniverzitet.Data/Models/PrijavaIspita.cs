using System;
using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class PrijavaIspita: IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int SlusaPredmetId { get; set; }
        public virtual SlusaPredmet SlusaPredmet { get; set; }

        public int IspitniTerminId { get; set; }
        public virtual IspitniTermin IspitniTermin { get; set; }

        public DateTime PrijavaDatum { get; set; }
 
        public DateTime? OdjavaDatum { get; set; }
    }
}