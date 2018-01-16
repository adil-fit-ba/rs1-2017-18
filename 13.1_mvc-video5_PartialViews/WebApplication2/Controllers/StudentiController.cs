using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class StudentiController : Controller
    {
        MojKontext kontext = new MojKontext();
        public IActionResult Index(string Unos)
        {
            var model = new StudentiImeVM {
                Studenti = kontext.studenti
               .Include(x => x.Grad)
                .Where(x => Unos == null || x.Grad.Naziv.StartsWith(Unos) ||(x.Ime+" "+x.Prezime).StartsWith(Unos) || (x.Prezime + " " + x.Ime).StartsWith(Unos))
                .ToList(), Unos = Unos
            };
             //izvršava SQL

            //kontext.Dispose();
            
            return View(model);
        }

       


        public IActionResult Snimi(string brIndexa, string ime, string prezime, int gradID, int StudentId)
        {
            Student x = null;
            if (StudentId != 0)
            {
                x = kontext.studenti.Find(StudentId);
            }
            else
            {
                x = new Student();
                kontext.studenti.Add(x);
            }

            x.Index = brIndexa;
            x.Ime = ime;
            x.Prezime = prezime;
            x.GradID = gradID;

            kontext.SaveChanges();

            return View("Snimi");
        }
        public IActionResult Dodaj()
        {
            var rows = new OcjeneVM
            {
                rows = new List<OcjeneVM.Row>()
            };
            StudentiUrediVM model = new StudentiUrediVM
            {
                edit = new Student(),
                gradovi = kontext.gradovi.ToList(),
                OcjeneVM = rows
            };
            return View("Uredi", model);
        }
        public IActionResult Obrisi(int id)
        {
            Student temp = kontext.studenti.Find(id);
            var rows = kontext.ocjeneStudenata.Where(x => x.StudentID == id).ToList();
            kontext.ocjeneStudenata.RemoveRange(rows);
            kontext.studenti.Remove(temp);
            kontext.SaveChanges();
            return RedirectToAction("index");
        }
        
        public IActionResult Uredi(int id)
        {
            var rows = new OcjeneVM {
                                        rows = kontext.ocjeneStudenata.Where(x => x.StudentID == id).
                                        Select(x => new OcjeneVM.Row
                                        {
                                            Ocjena = x.Vrijednost,
                                            OcjenaOpis = x.VrijednostOpisna,
                                            datum = x.datum
                                        }).ToList() };
            StudentiUrediVM model = new StudentiUrediVM
            {
                edit = kontext.studenti.Find(id),
                gradovi = kontext.gradovi.ToList(),
                OcjeneVM = rows
            };

            return View(model);
        }
    }
}