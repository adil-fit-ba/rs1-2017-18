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
            ViewData["ulazniModel"] = new OdjeljenjeIndexVM
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
            return View("Index");
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

            ViewData["ulazniModel"] = ulazniModel;
            return View();
        }

        public IActionResult Snimi(string skolaGodina, int razred, string oznaka, int razrednikID, int odjeljenjeID)
        {
            Odjeljenje o1 = _context.Odjeljenje.Find(odjeljenjeID);
           

            Odjeljenje o2 = new Odjeljenje
            {
                RazrednikID = razrednikID,
                IsPrebacenuViseOdjeljenje = false,
                Oznaka = oznaka,
                Razred = razred,
                SkolskaGodina = skolaGodina
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
                    }
                }
            }

          
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}