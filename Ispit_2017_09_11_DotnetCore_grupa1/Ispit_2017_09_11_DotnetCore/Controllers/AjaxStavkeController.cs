using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            model.OdjeljenjeID = odjeljenjeID;

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

        public IActionResult Dodaj(int odjeljenjeId)
        {
            StavkeUrediVM model=new StavkeUrediVM();

            model.OdjeljenjeID = odjeljenjeId;

            model.UceniciSelectListItems =
                _context.Ucenik.Select(x => new SelectListItem {Text = x.ImePrezime, Value = x.Id.ToString()}).ToList();

            return PartialView(model);
        }

        public IActionResult Snimi(StavkeUrediVM model)
        {
            OdjeljenjeStavka odjeljenjeStavka;
            if (model.OdjeljenjeStavkaID == 0)
            {
                odjeljenjeStavka = new OdjeljenjeStavka();
                _context.OdjeljenjeStavka.Add(odjeljenjeStavka);
            }
            else
            {
                odjeljenjeStavka = _context.OdjeljenjeStavka.Find(model.OdjeljenjeStavkaID);
            }

            odjeljenjeStavka.OdjeljenjeId = model.OdjeljenjeID;
            odjeljenjeStavka.BrojUDnevniku = model.BrojUDnevniku;
            odjeljenjeStavka.UcenikId = model.UcenikID;

            _context.SaveChanges();

            return RedirectToAction("Index", new {odjeljenjeId = model.OdjeljenjeID});
        }

        public IActionResult Uredi(int odjeljenjeStavkaId)
        {
            StavkeUrediVM model = new StavkeUrediVM();

            OdjeljenjeStavka odjeljenjeStavka = _context.OdjeljenjeStavka.Find(odjeljenjeStavkaId);

            model.OdjeljenjeStavkaID = odjeljenjeStavka.Id;
            model.OdjeljenjeID = odjeljenjeStavka.OdjeljenjeId;
            model.UcenikID = odjeljenjeStavka.UcenikId;
            model.BrojUDnevniku = odjeljenjeStavka.BrojUDnevniku;

            model.UceniciSelectListItems =
                _context.Ucenik.Select(x => new SelectListItem { Text = x.ImePrezime, Value = x.Id.ToString() }).ToList();

            return PartialView("Dodaj",model);
        }
    }
}