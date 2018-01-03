

namespace eUniverzitet.Data.Models
{
    public enum AngaziranNaPredmetTip
    {
        PredmetniNastavnik,
        Asistent,
        Ostalo
    }
    public class AngaziranNaPredmet 
    {
        public int Id { get; set; }

        

        public int IzvodjenjePredmetaId { get; set; }
        public virtual IzvodjenjePredmeta IzvodjenjePredmeta { get; set; }

        public int NastavnoOsobljeId { get; set; }
        public virtual NastavnoOsoblje NastavnoOsoblje { get; set; }

        public AngaziranNaPredmetTip AngaziranNaPredmetTip { get; set; }
    }
}
