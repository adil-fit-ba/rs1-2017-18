using System;
using System.Collections.Generic;
using eUniverzitet.Data.Models;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class ZaposlenikIndexVM
    {
        public class ZaposlenjeInfo
        {
            public string OrganizacionaJedinica { get; set; }
            public string RadnoMjesto { get; set; }
            public DateTime DatumPocetak { get; set; }
            public DateTime? DatumKraja { get; set; }
            public KorisnickaUloga KorisnickaUloga { get; set; }
            public int Id { get; set; }
        }


        public class ZaposlenikInfo
        {
            public List<ZaposlenjeInfo> Zaposlenjas { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public int Id { get; set; }
            public int KorisnikId { get; set; }
        }

        public List<ZaposlenikInfo> TabelaPodaci { get; set; }
    }
}