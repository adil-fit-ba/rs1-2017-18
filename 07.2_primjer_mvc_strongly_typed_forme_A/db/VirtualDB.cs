using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.db
{
    public class VirtualDB
    {
        private static List<Student> _student = null;
        public static List<Student> student {
            get
            {
                if(_student==null)
                {
                    _student = new List<Student>();
                    _student.Add(new Student {id=1,ime="Amina",prezime="Cerkez" });
                    _student.Add(new Student { id =2, ime = "Neki", prezime = "Nekic" });
                    _student.Add(new Student { id = 3, ime = "Neki2", prezime = "Nekic2" });


                }
                return _student;
            }
        }

        private static List<Grad> _Grad = null;
        public static List<Grad> Grad
        {
            get
            {
                if (_Grad == null)
                {
                    _Grad = new List<Grad>();
                    _Grad.Add(new Grad { id = 1, Naziv = "Mostar"});
                    _Grad.Add(new Grad { id = 2, Naziv = "Sarajevo"});
                    _Grad.Add(new Grad { id = 3, Naziv = "Zenica"});


                }
                return _Grad;
            }
        }


    }
}
