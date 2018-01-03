using System.Collections.Generic;
using eUniverzitet.Data.Models;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Models
{
    public class AngaziranNaPredmetuIndexVM
    {
        public class NastavnoOsobljeInfo
        {
            public int Id { get; set; }
            public string ImeIPrezime { get; set; }
            public NastavnoOsobljeZvanje Zvanje { get; set; }
            public AngaziranNaPredmetTip Uloga { get; set; }
        }

        public List<NastavnoOsobljeInfo> TabelaPodaci { get; set; }
    
        public int IzvodjenjePredmetaId { get; set; }
    }
}