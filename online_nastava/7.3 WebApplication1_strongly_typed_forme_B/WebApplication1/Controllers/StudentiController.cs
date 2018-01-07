using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.db;
using WebApplication1.ViewModels;
using static WebApplication1.helper.G;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class StudentiController : Controller
    {

        VirtualEF nesto = new VirtualEF();
        public IActionResult Index()
        {
            var model = new StudentiIndexVM
            {
                studenti = nesto._studenti.ToList(),
                opisi = new List<string> { "str1", "str2", },
               
            };
            return View("index", model);
        }


        public IActionResult Dodaj()
        {
            var gradovi = nesto._gradovi
                .Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.Naziv
            }).ToList();

            var zanimanja = new List<SelectListItem> {
                    new SelectListItem{Text="IT"},
                    new SelectListItem{Text="DevOps"},
                    new SelectListItem{Text="Developer"},
                };

            StudentUrediVM model = new StudentUrediVM
            {
                student = new Student(),
                gradovi = gradovi,
                zanimanja = zanimanja,
            };

            return View("Uredi",model);
        }

        [HttpGet]
        public IActionResult Snimi(int id, string ime, string prezime, string DL, string pass, string zanimanje, int? grad)
        {
            Student obj = new Student
            {
                id = id,
                ime = ime,
                prezime = prezime,
                password = pass,
                zanimanje = zanimanje,
                isDL = DL == "On",
                Grad = nesto._gradovi.Where(x => x.id == grad).FirstOrDefault()
            };
            


            if (obj.id == 0)
            {
                //obj.id = nesto._studenti.Max(s => s.id) + 1;
                nesto._studenti.Add(obj);
            }
            else {
                // Student s = nesto._studenti.Where(x => x.id == obj.id).FirstOrDefault();
                // VirtualDB.student.Remove(s);
                //  VirtualDB.student.Add(obj);
                nesto._studenti.Update(obj);

            }
            nesto.SaveChanges();

            return Redirect("/Studenti/Index");

        }

        public string Proba(string ime, int godiste, bool potvrda)
        {

            return "<h1>Ok</h1>";
        }

        public IActionResult Obrisi(int id)
        {
            Student x = nesto._studenti.Where(i => i.id == id).SingleOrDefault();
            nesto._studenti.Remove(x);
            nesto.SaveChanges();
            return Redirect("/Studenti/Index");

        }

        public IActionResult Uredi(int id) {
            var student = nesto._studenti.Where(x => x.id == id).FirstOrDefault();

            if (student == null)
                return RedirectToAction("index");

            var gradovi = nesto._gradovi
                .Select(s => new SelectListItem
                {
                    Value = s.id.ToString(),
                    Text = s.Naziv
                }).ToList();

            var zanimanja = new List<SelectListItem> {
                    new SelectListItem{Text="IT"},
                    new SelectListItem{Text="DevOps"},
                    new SelectListItem{Text="Developer"},
                };

            StudentUrediVM model = new StudentUrediVM
            {
                student = student,
                gradovi = gradovi,
                zanimanja = zanimanja,
            };

            return View(model);
        }
    }

  
}