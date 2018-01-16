using System.Collections.Generic;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Models
{
    public class PredmetIndexVM
    {
        public class PredmetInfo
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public float Ects { get; set; }
            public int GodinaStudija { get; set; }
            public int NppId { get; set; }
        }

        public List<PredmetInfo> TabelaPodaci { get; set; }

        public string FakultetNaziv { get; set; }
        public int FakultetId { get; set; }

        public string OdsjekNaziv { get; set; }
        public int OdsjekId { get; set; }

        public string NppNaziv { get; set; }
        public int NppId { get; set; }
    }
}