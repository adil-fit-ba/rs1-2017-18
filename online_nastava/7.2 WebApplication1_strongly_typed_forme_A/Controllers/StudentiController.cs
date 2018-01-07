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
        
        public IActionResult Index()
        {
            var model = new StudentiIndexVM
            {
                studenti = VirtualDB.student,
                opisi = new List<string> { "str1", "str2", },
               
            };
            return View("index", model);
        }


        public IActionResult Dodaj()
        {
            StudentDodajVM model = new StudentDodajVM
            {   gradovi = VirtualDB.Grad.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.Naziv
            }).ToList(),
                zanimanja = new List<SelectListItem> {
                    new SelectListItem{Text="IT"},
                    new SelectListItem{Text="DevOps"},
                    new SelectListItem{Text="Developer"},
                }
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Snimi(string ime, string prezime, string DL, string pass, string zanimanje, int? grad)
        {
            Student obj = new Student
            {
                ime = ime,
                prezime = prezime,
                password=pass,
                zanimanje=zanimanje,
                isDL = DL == "On",
                id = VirtualDB.student.Max(s=>s.id)+1
            };

            VirtualDB.student.Add(obj);

            return Redirect("/Studenti/Index");

        }

        public string Proba(string ime, int godiste, bool potvrda)
        {

            return "<h1>Ok</h1>";
        }

        public IActionResult Obrisi(int id)
        {
            Student x = VirtualDB.student.Where(i => i.id == id).SingleOrDefault();
            VirtualDB.student.Remove(x);
            return Redirect("/Studenti/Index");

        }
    }

  
}