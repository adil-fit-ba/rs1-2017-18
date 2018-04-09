using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using Ispit.Data;
using Ispit.Web.ViewModels;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Web.Controllers
{
[Autorizacija(ucenik: false, nastavnici: true)]
[Area("NastavnikModul")]
    public class OdjeljenjeController : Controller
    {
        private MyContext _context;

        public OdjeljenjeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            if (korisnik == null)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija");
            }
            var model = new OdjeljenjeIndexVM
            {
                rows = _context.Odjeljenje
                    .Select(x => new OdjeljenjeIndexVM.Row
                    {
                        Razrednik = x.Razrednik.ImePrezime,
                        Oznaka = x.Oznaka,
                        IsPrebacenuViseOdjeljenje = x.IsPrebacenuViseOdjeljenje,
                        Razred = x.Razred,
                        SkolskaGodina = x.SkolskaGodina,
                        prosjekOcjena =
                            _context.DodjeljenPredmet.Where(s => s.OdjeljenjeStavka.OdjeljenjeId == x.Id)
                                .Average(a => (int?) a.ZakljucnoKrajGodine) ?? 0,
                        najboljiUcenik = "??",
                        OdjeljenjeId = x.Id
                    })
                    .ToList()
            };
            return View("Index", model);
        }

        public IActionResult Obrisi(int id)
        {
            Odjeljenje x = _context.Odjeljenje.Find(id);

            if (x.RazrednikID != HttpContext.GetLogiraniKorisnik().Id)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija", new {Area=""});
            }

            _context.Odjeljenje.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Dodaj()
        {
            var ulazniModel = new OdjeljenjeDodajVM();
            pripremiCmbStavke(ulazniModel);


            return View(ulazniModel);
        }

        private void pripremiCmbStavke(OdjeljenjeDodajVM ulazniModel)
        {
            ulazniModel.nastavnik = HttpContext.GetLogiraniKorisnik().KorisnickoIme;

            ulazniModel.odjeljenja = _context.Odjeljenje
                .Where(x => !x.IsPrebacenuViseOdjeljenje)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.SkolskaGodina + ",  " + x.Oznaka,
                })
                .ToList();
        }

        public IActionResult ProvjeriOznaku(string oznaka, string skolaGodina)
        {
            if (_context.Odjeljenje.Any(x => x.Oznaka == oznaka && x.SkolskaGodina == skolaGodina))
                return Json($"Oznaka {oznaka} je zauzeta za šk. godinu {skolaGodina}");

            return Json(true);
        }

        public IActionResult Detalji(int id)
        {
            Odjeljenje x = _context.Odjeljenje.Where(w=>w.Id == id)
                .Include(q=>q.Razrednik)
                .SingleOrDefault();


            OdjeljenjeDetaljiVM model = new OdjeljenjeDetaljiVM
            {
                Razrednik = x.Razrednik.ImePrezime,
                Oznaka = x.Oznaka,
                Razred = x.Razred,
                SkolskaGodina = x.SkolskaGodina,
                BrojPredmta = _context.Predmet.Where(w=>x.Razred == x.Razred).Count(),
                OdjeljenjeID=x.Id,
                BrojUcenika = _context.OdjeljenjeStavka.Where(w => w.OdjeljenjeId== id).Count(),

            };
            return View("Detalji", model);
        }


        public IActionResult Snimi(OdjeljenjeDodajVM input)
        {

            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("Dodaj", input);
            }

            Odjeljenje o1 = _context.Odjeljenje.Find(input.odjeljenjeID);


            Odjeljenje o2 = new Odjeljenje
            {
                
                RazrednikID = _context.Nastavnik.Where(x=>x.KorisnickiNalogId == HttpContext.GetLogiraniKorisnik().Id).Select(s=>s.NastavnikID).Single(),
                IsPrebacenuViseOdjeljenje = false,
                Oznaka = input.oznaka,
                Razred = input.razred,
                SkolskaGodina = input.skolaGodina
            };
            _context.Odjeljenje.Add(o2);
            _context.SaveChanges();

            if (o1 != null)
            {
                o1.IsPrebacenuViseOdjeljenje = true;
                int b = 0;
                IQueryable<OdjeljenjeStavka> s1s = _context.OdjeljenjeStavka.Where(x => x.OdjeljenjeId == o1.Id);



                foreach (OdjeljenjeStavka s1 in s1s)
                {
                    int brojNegativnihOcjena = _context.DodjeljenPredmet.Where(x => x.OdjeljenjeStavkaId == s1.Id)
                        .Count(q => q.ZakljucnoKrajGodine == 1);

                    if (brojNegativnihOcjena == 0)
                    {
                        OdjeljenjeStavka s2 = new OdjeljenjeStavka
                        {
                            OdjeljenjeId = o2.Id,
                            UcenikId = s1.UcenikId,
                            BrojUDnevniku = ++b,
                        };
                        _context.OdjeljenjeStavka.Add(s2);

                        List<Predmet> predmeti = _context.Predmet.Where(a => a.Razred == o2.Razred).ToList();
                        foreach (Predmet x in predmeti)
                        {
                            _context.DodjeljenPredmet.Add(new DodjeljenPredmet
                            {
                                OdjeljenjeStavka = s2,
                                ZakljucnoKrajGodine = 0,
                                ZakljucnoPolugodiste = 0,
                                PredmetId = x.Id
                            });
                        }
                    }
                }
            }


            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}