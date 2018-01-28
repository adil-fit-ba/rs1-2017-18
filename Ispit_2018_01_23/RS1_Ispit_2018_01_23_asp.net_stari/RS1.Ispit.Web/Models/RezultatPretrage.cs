using System;

namespace RS1.Ispit.Web.Models
{
    public class RezultatPretrage
    {
        public int Id { get; set; }
        public virtual Uputnica Uputnica { get; set; }
        public int UputnicaId { get; set; }

        public virtual LabPretraga LabPretraga { get; set; }
        public int PretragaId { get; set; }


        public int? ModalitetId { get; set; }
        public virtual Modalitet Modalitet { get; set; }
        public double? NumerickaVrijednost { get; set; }
    }
}
