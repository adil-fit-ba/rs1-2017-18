using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Db;
using WebApplication5.EntityModels;

namespace WebApplication5.Controllers
{
    public class StudentiController : Controller
    {
        private VirtualDB _db = new VirtualDB();
        public IActionResult Index()
        {
            List<Student> podaci1 = _db._studenti
                .Include(x=>x.Opstina)
                .ToList();
            ViewData["kljuc1"] = podaci1;
            return View();
        }

        public IActionResult Dodaj()
        {
            Student s = new Student();
            ViewData["kljuc1"] = s;
            return View("Edit");
        }

        public IActionResult Edit(int id)
        {
            Student s = _db._studenti.Find(id);
            ViewData["kljuc1"] = s;
            return View("Edit");
        }


        public IActionResult Snimi(int studentid, string ime, string prezime, int opstinaId)
        {
            Student s;
            if (studentid != 0)
            {
                s = _db._studenti.Find(studentid);
            }
            else
            {
                s = new Student();
                _db._studenti.Add(s);
            }

            s.Ime = ime;
            s.OpstinaId = opstinaId;
            s.Prezime = prezime;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int id)
        {
            Student p1 = _db._studenti.Where(x => x.Id == id).FirstOrDefault();
            _db._studenti.Remove(p1);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}