using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Data;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using eUniverzitet.Web.Models;

namespace eUniverzitet.Web.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{

        //    Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

        //    if (k == null)
        //        return RedirectToAction("Logout", "Autentifikacija", new { area = "" });

        //    if (k.Zaposlenik != null)
        //        return RedirectToAction("Index", "Home", new { area = "ModulZaposlenik" });

        //    if (k.Student != null)
        //        return RedirectToAction("Index", "Home", new { area = "ModulStudenti" });

        //    return RedirectToAction("Logout", "Autentifikacija", new { area = "" });
        //}

    }
}
