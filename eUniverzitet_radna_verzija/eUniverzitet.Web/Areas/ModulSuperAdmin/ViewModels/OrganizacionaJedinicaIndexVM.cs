using System.Collections.Generic;
using eUniverzitet.Data.Models;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class OrganizacionaJedinicaIndexVM
    {
        public class Info
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public OrganizacionaJedinicaTip Tip { get; set; }
        }

        public List<Info> TabelaPodaci { get; set; }
    }
}