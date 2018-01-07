using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.model;

namespace WebApplication5.Controllers
{
    public class StudentiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dodaj1()
        {
            ViewData["saljemIme"] = "default ime";
            ViewData["saljemPrezime"] = "default prezime";
            return View();
        }

        public string Snimi1(string txtIme, string txtPrezime)
        {
            
            return "Zdravo, " +txtIme + " " + txtPrezime;
        }

      
        public IActionResult Dodaj2()
        {
            Student model = new Student {Ime = "default ime", Prezime = "default prezime"};
            return View(model);
        }

        public string Snimi2(Student model)
        {
            return "Zdravo, " + model.Ime + " " + model.Prezime;
        }
    }
}