using System.Collections.Generic;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class FakultetIndexVM
    {
        public class Info
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public int BrojOdsjeka { get; set; }
            public int BrojStudenata { get; set; }
            public string NaucnaOblast { get; set; }
        }

        public List<Info> TabelaPodaci { get; set; }
    }
}