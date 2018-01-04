using System;
using System.Collections.Generic;
using eUniverzitet.Data.Models;

namespace eUniverzitet.Web.Areas.ModulZaposlenik.Models
{
    public class HomeIndexVM
    {
        public class ZaposlenjaInfo
        {
            public int ZaposlenjeId { get; set; }
            public string OrganizacionaJedinica { get; set; }
            public string RadnoMjestoVrsta { get; set; }
            public DateTime UgovorPocetak { get; set; }
            public DateTime? UgovorKraj { get; set; }
            public KorisnickaUloga KorisnickaUloga { get; set; }
           
        }

        public List<ZaposlenjaInfo> TabelaPodaci { get; set; }

    }
}