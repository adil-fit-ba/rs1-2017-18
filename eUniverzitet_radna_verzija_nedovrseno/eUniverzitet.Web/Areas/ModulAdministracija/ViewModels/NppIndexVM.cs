using System.Collections.Generic;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Models
{
    public class NppIndexVM
    {
        public class NppInfo
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public string AkademskaGodina { get; set; }
        }

        public List<NppInfo> TabelaPodaci { get; set; }

        public string FakultetNaziv { get; set; }
        public int FakultetId { get; set; }

        public string OdsjekNaziv { get; set; }
        public int OdsjekId { get; set; }
        
    }
}