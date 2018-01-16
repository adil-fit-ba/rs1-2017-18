using System.Collections.Generic;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Models
{
    public class PredajeIndexVM
    {
        public class NastavnoOsobljeInfo
        {
            public string ImeIPrezime { get; set; }
            public string Zvanje { get; set; }
        }
        public class PredajeInfo
        {
            public int Id { get; set; }
            public List<NastavnoOsobljeInfo> AngaziranoNastavnoOsoblje { get; set; }
            public string Predmet { get; set; }
            public string AkademskaGodina { get; set; }
        }
        public List<PredajeInfo> TabelaPodaci { get; set; }
    
        public string FakultetNaziv { get; set; }
        public int FakultetId { get; set; }

        public string OdsjekNaziv { get; set; }
        public int OdsjekId { get; set; }

        public string NppNaziv { get; set; }
        public int NppId { get; set; }

        public string PredmetNaziv { get; set; }
        public int PredmetId { get; set; }
    }
}