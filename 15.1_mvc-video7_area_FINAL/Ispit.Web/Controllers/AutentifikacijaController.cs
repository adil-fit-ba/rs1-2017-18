using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using eUniverzitet.Web.ViewModels;
using Ispit.Data;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly MyContext _db;

        public AutentifikacijaController(MyContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                    ZapamtiPassword    = true,
            });
        }

        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnik = _db.KorisnickiNalog
                .SingleOrDefault(x => x.KorisnickoIme == input.username /*&& x.Lozinka == input.password*/);

            if (korisnik == null)
            {
                TempData["error_poruka"] = "pogrešan username ili password";
                return View("Index", input);
            }

            HttpContext.SetLogiraniKorisnik(korisnik, input.ZapamtiPassword);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {

            return RedirectToAction("Index");
        }
    }
}