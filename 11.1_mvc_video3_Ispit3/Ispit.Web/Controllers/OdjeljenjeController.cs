using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit.Data;
using Ispit.Web.ViewModels;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Web.Controllers
{
    public class OdjeljenjeController : Controller
    {
        private MyContext _context;

        public OdjeljenjeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
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
            _context.Odjeljenje.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Dodaj()
        {
            var ulazniModel = new OdjeljenjeDodajVM();
            ulazniModel.nastavnici = _context.Nastavnik
              .Select(x=>new SelectListItem
                {
                        Value = x.NastavnikID.ToString(),
                        Text = x.ImePrezime
                })
                .ToList();

            ulazniModel.odjeljenja = _context.Odjeljenje
                .Where(x=>!x.IsPrebacenuViseOdjeljenje)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.SkolskaGodina + ",  " + x.Oznaka,
                })
                .ToList();

          
            return View(ulazniModel);
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
            Odjeljenje o1 = _context.Odjeljenje.Find(input.odjeljenjeID);


            Odjeljenje o2 = new Odjeljenje
            {
                RazrednikID = input.razrednikID,
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