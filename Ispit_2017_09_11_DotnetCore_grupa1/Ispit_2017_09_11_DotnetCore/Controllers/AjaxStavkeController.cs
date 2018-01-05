using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class AjaxStavkeController : Controller
    {
        private MojContext _context;
        public AjaxStavkeController(MojContext context)
        {
            this._context = context;
        }
        public IActionResult Index(int odjeljenjeID)
        {
            StavkeIndexVM model = new StavkeIndexVM();
            model.Rows = _context.OdjeljenjeStavka
                .Where(x => x.OdjeljenjeId == odjeljenjeID)
                .Select(y => new StavkeIndexVM.Row
                {
                    BrojUDnevniku = y.BrojUDnevniku,
                    BrojZakljucnihOcjena = _context.DodjeljenPredmet.Count(s => s.OdjeljenjeStavkaId ==y.Id),
                    OdjeljenjeStavkaID = y.Id,
                    Ucenik = y.Ucenik.ImePrezime
                })
                .ToList();
            return PartialView(model);
        }

        public IActionResult Obrisi(int OdjeljenjeStavkaId)
        {
            var x = _context.OdjeljenjeStavka.Find(OdjeljenjeStavkaId);
            int id = x.OdjeljenjeId;
            _context.OdjeljenjeStavka.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", new {odjeljenjeID = id});
            //  return Redirect("/Stavke/Index?odjeljenjeID="+OdjeljenjeStavkaId);
        }

        public IActionResult Dodaj()
        {
            return null;
        }

        public IActionResult Snimi()
        {
            return null;
        }

        public IActionResult Uredi()
        {
            return null;
        }
    }
}