using System.Collections.Generic;
using System.Linq;

namespace eUniverzitet.Data.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public KorisnickaUloga KorisnickaUloga { get; set; }

        public List<Student> Students { get; set; }

       

        public List<Zaposlenik> Zaposleniks { get; set; }
       

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Ime_prezime
        {
            get { return Ime + " " + Prezime; }
        }

        public string Prezime_ime
        {
            get { return Prezime + " " + Ime; }
        }
    }
}
