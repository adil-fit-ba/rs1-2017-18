using System.Collections.Generic;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Models
{
    public class IzvodjenjePredmetaIndexVM
    {
        public class NastavnoOsobljeInfo
        {
            public string ImeIPrezime { get; set; }
            public string Zvanje { get; set; }
            public string Uloga { get; set; }
        }
        public class IzvodjenjeInfo
        {
            public int Id { get; set; }
            public List<NastavnoOsobljeInfo> AngaziranoNastavnoOsoblje { get; set; }
            public string Predmet { get; set; }
            public string AkademskaGodina { get; set; }
        }
        public List<IzvodjenjeInfo> TabelaPodaci { get; set; }
    
        public int PredmetId { get; set; }
        public string PredmetNaziv { get; set; }
    }
}