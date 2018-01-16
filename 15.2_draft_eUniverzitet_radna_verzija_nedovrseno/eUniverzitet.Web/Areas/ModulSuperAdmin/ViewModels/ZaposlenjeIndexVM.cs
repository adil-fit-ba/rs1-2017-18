using System;
using System.Collections.Generic;
using eUniverzitet.Data.Models;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class ZaposlenjeIndexVM
    {
        public class ZaposlenjeInfo
        {
            public int Id { get; set; }

            public string OrganizacionaJedinica { get; set; }
            public string RadnoMjesto { get; set; }
            public DateTime DatumPocetak { get; set; }
            public DateTime? DatumKraja { get; set; }
            public KorisnickaUloga KorisnickaUloga { get; set; }
        }


        public List<ZaposlenjeInfo> TabelaPodaci { get; set; }
        public int ZaposlenikId { get; set; }
    }
}