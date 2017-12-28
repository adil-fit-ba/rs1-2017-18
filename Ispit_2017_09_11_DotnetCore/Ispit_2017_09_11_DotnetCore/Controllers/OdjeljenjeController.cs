using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class OdjeljenjeController : Controller
    {
        private MojContext _context;

        public OdjeljenjeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            OdjeljenjeIndexVM model = new OdjeljenjeIndexVM();
            model.Rows = _context.Odjeljenje
                .Select(x => new OdjeljenjeIndexVM.Row
                {
                    OdjeljenjeID = x.Id,
                    SkolskaGodina = x.SkolskaGodina,
                    Razred = x.Razred,
                    Oznaka = x.Oznaka,
                    Razrednik = x.Nastavnik.ImePrezime,
                    Prebacen = x.IsPrebacenuViseOdjeljenje,
                    ProsjekOcjena = _context.DodjeljenPredmet
                    .Where(c=>c.OdjeljenjeStavka.OdjeljenjeId == x.Id)
                    .Average(a=>(double?)a.ZakljucnoKrajGodine)??0
                }).ToList();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            return View();
        }

        public IActionResult Detalji(int odjeljenjeID)
        {
            Odjeljenje a = _context.Odjeljenje.Find(odjeljenjeID);
            OdjeljenjeDetaljiVM model = new OdjeljenjeDetaljiVM(a, _context);

            return View(model);
        }

        public IActionResult Obrisi(int odjeljenjeID)
        {
            Odjeljenje a = _context.Odjeljenje.Find(odjeljenjeID);
            _context.Odjeljenje.Remove(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}