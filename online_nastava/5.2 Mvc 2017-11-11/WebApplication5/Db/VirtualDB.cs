using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.EntityModels;

namespace WebApplication5.Db
{
    public class VirtualDB
    {
        private static List<Student> _studenti = null;

        public static List<Student> student
        {
            get
            {
                if (_studenti == null)
                {
                    _studenti = new List<Student>();
                    _studenti.Add(new Student { Id = 1, Ime = "Amina", Prezime = "Cerkez" });
                    _studenti.Add(new Student { Id = 2, Ime = "Neki",  Prezime = "Nekic" });
                    _studenti.Add(new Student { Id = 3, Ime = "Neki2", Prezime = "Nekic2" });
                }
                return _studenti;
            }
        }
    }
}
