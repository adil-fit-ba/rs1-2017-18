using System.Collections.Generic;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class AkademskaGodinaIndexVM
    {
        public class AkademskaGodinaInfo
        {
            public string Opis { get; set; }
            public int Id { get; set; }
        }

        public List<AkademskaGodinaInfo> TabelaPodaci { get; set; }
    }
}