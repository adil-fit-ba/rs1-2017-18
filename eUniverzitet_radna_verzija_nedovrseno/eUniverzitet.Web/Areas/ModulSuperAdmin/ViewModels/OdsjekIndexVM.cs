using System.Collections.Generic;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class OdsjekIndexVM
    {
        public class OdsjekInfo
        {
            public string OdsjekNaziv { get; set; }
            public int BrojStudenata { get; set; }
            public int Id { get; set; }
        }

        public List<OdsjekInfo> TabelaPodaci { get; set; }
        public int? FakultetId { get; set; }
        public string FakultetNaziv { get; set; }
    }
}