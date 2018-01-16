using System.Collections.Generic;
using System.Linq;

namespace eUniverzitet.Data.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public List<Student> Students { get; set; }

        public Student Student
        {
            get
            {
                return Students.FirstOrDefault();
            }
        }

        public List<Zaposlenik> Zaposleniks { get; set; }
        public Zaposlenik Zaposlenik
        {
            get
            {
                return Zaposleniks.FirstOrDefault();
            }
        }

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
