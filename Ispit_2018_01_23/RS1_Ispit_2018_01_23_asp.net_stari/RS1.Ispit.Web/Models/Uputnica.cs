using System;

namespace RS1.Ispit.Web.Models
{
    public class Uputnica
    {
        public int Id { get; set; }
        public virtual Ljekar UputioLjekar{ get; set; }
        public int UputioLjekarId { get; set; }

        public virtual Ljekar LaboratorijLjekar { get; set; }
        public int? LaboratorijLjekarId { get; set; }

        public virtual Pacijent Pacijent { get; set; }
        public int PacijentId { get; set; }

        public virtual VrstaPretrage VrstaPretrage { get; set; }
        public int VrstaPretrageId { get; set; }

        public DateTime DatumUputnice { get; set; }
        public DateTime? DatumRezultata { get; set; }
        public bool IsGotovNalaz{ get; set; }
    }
}
