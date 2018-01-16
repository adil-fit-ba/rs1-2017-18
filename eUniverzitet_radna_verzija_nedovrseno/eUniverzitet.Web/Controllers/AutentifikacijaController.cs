using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using eUniverzitet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        MojContext _db;

        public AutentifikacijaController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginVM input)
        {
            Korisnik korisnik = _db.Korisniks
                .SingleOrDefault(x => x.KorisnickoIme == input.username && x.Lozinka == input.password);

            if (korisnik == null)
            {
                ViewData["poruka"] = "pogrešan username ili password";
                return View("Index", input);
            }

            Autentifikacija.PokreniNovuSesiju(korisnik, HttpContext);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            Autentifikacija.PokreniNovuSesiju(null, HttpContext);

            return RedirectToAction("Login");
        }
    }
}