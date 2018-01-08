using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit.Data;
using Ispit.Web.ViewModels;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit.Web.Controllers
{
    public class StavkeAjaxController : Controller
    {
        private MyContext _context;

        public StavkeAjaxController(MyContext context)
        {
            this._context = context;
        }

        public IActionResult Index(int odjeljenjeId)
        {
            StavkeIndexVM model = new StavkeIndexVM
            {
                OdjeljenjeId = odjeljenjeId,
                rows = _context.OdjeljenjeStavka.Where(x => x.OdjeljenjeId == odjeljenjeId)
                .Select(s=>new StavkeIndexVM.Row
                    {
                        BrojUDnevniku = s.BrojUDnevniku,
                        Ucenik = s.Ucenik.ImePrezime,
                        BrojZakljucihOcjena  = _context.DodjeljenPredmet.Where(q=>q.OdjeljenjeStavkaId == s.Id).Count(a=>a.ZakljucnoKrajGodine!= 0),
                        OdjeljenjeStavkeId = s.Id
                    }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Obrisi(int id)
        {
            OdjeljenjeStavka x = _context.OdjeljenjeStavka.Find(id);
            int o = x.OdjeljenjeId;
            _context.OdjeljenjeStavka.Remove(x);
            _context.SaveChanges();
      //      return RedirectToAction("Index");
            
            return Redirect("/StavkeAjax/Index?odjeljenjeId=" + o);
        }

        public IActionResult Uredi(int id)
        {

            OdjeljenjeStavka x = _context.OdjeljenjeStavka.Find(id);


            StavkeDodajVM model = new StavkeDodajVM
            {
                BrojUdnevniku = x.BrojUDnevniku,
                OdjeljenjeID = x.OdjeljenjeId,
                OdjeljenjeStavkaId = id,
                UcenikID = x.UcenikId,
                ucenici = _context.Ucenik.Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.ImePrezime
                }).ToList()
            };

            return PartialView("Dodaj", model);
        }

        public IActionResult Dodaj(int odjeljenjeId)
        {
            StavkeDodajVM model = new StavkeDodajVM
            {
                BrojUdnevniku = _context.OdjeljenjeStavka.Count(s => s.OdjeljenjeId==odjeljenjeId) + 1,
                OdjeljenjeID = odjeljenjeId,
                UcenikID = 0,
                ucenici = _context.Ucenik.Select(x=>new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.ImePrezime
                }).ToList()
            };
            return PartialView("Dodaj", model);
        }

        public IActionResult Snimi(int OdjeljenjeStavkaId, int OdjeljenjeID, int BrojUdnevniku, int UcenikID)
        {
            OdjeljenjeStavka x;

            if (OdjeljenjeStavkaId == 0)
            {
                x = new OdjeljenjeStavka();
                 _context.OdjeljenjeStavka.Add(x);
            }
            else
            {
                x = _context.OdjeljenjeStavka.Find(OdjeljenjeStavkaId);
            }

            x.OdjeljenjeId = OdjeljenjeID;
            x.UcenikId = UcenikID;
            x.BrojUDnevniku = BrojUdnevniku;

           
            _context.SaveChanges();
            return Redirect("/StavkeAjax/Index?odjeljenjeId=" + OdjeljenjeID);
        }
    }
}