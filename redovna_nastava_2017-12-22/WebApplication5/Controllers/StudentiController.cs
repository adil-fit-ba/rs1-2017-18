using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.EF;
using WebApplication5.EntityModels;

namespace WebApplication5.Controllers
{
    public class StudentiController : Controller
    {
        public StudentiController(MojContext context)
        {
            _db = context;
        }

        private MojContext _db;
        public IActionResult Index()
        {
            List<Student> podaci1 = _db.Studenti
                .Include(x => x.Opstina)
                .ToList();
            ViewData["kljuc1"] = podaci1;
            return View();
        }

        private class JsonPretaga
        {
            public string name { get; set; }
            public string email { get; set; }

        }
        public IActionResult Trazi()
        {
            List<JsonPretaga> podaci1 = _db.Studenti
                .Select(x => new JsonPretaga
                {
                    name = x.Ime + " " + x.Prezime,
                    email = x.Opstina.Opis
                })
                .ToList();


            return Json(podaci1);
        }

        public IActionResult IndexPartial()
        {
            List<Student> podaci1 = _db.Studenti
                .Include(x => x.Opstina)
                .ToList();
            ViewData["kljuc1"] = podaci1;
            return PartialView("Index");
        }

        public IActionResult Dodaj()
        {
            Student s = new Student();
            ViewData["kljuc1"] = s;
            return View("Edit");
        }

        public IActionResult DodajPartial()
        {
            Student s = new Student();
            ViewData["kljuc1"] = s;
            return PartialView("Edit");
        }

        public IActionResult Danas22()
        {
            return PartialView();
        }

        public IActionResult Proba()
        {
            Student s = new Student();
            ViewData["kljuc1"] = s;
            return PartialView("Edit");
        }

        public IActionResult Edit(int id)
        {
            Student s = _db.Studenti.Find(id);
            ViewData["kljuc1"] = s;
            return View("Edit");
        }


        public IActionResult Snimi(int studentid, string ime, string prezime, int opstinaId)
        {
            Student s;
            if (studentid != 0)
            {
                s = _db.Studenti.Find(studentid);
            }
            else
            {
                s = new Student();
                _db.Studenti.Add(s);
            }

            s.Ime = ime;
            s.OpstinaId = opstinaId;
            s.Prezime = prezime;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int id)
        {
            Student p1 = _db.Studenti.Where(x => x.Id == id).FirstOrDefault();
            _db.Studenti.Remove(p1);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult JsonGradovi()
        {
            List<JsonGrad> r = _db.Opstine
                .Select(x => new JsonGrad
                {
                    code = x.Id.ToString(),
                    name = x.Opis
                })
                .ToList();

            return Json(r);
        }

        private class JsonGrad
        {
            public string code { get; set; }
            public string name { get; set; }
        }
    }
}