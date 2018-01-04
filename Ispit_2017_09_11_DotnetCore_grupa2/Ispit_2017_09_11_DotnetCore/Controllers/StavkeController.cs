using System.Linq;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class StavkeController : Controller
    {
        private MojContext db;

        public StavkeController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int OdjeljenjeID)
        {
            StavkeIndexVM model = new StavkeIndexVM
            {
                OdjeljenjId = OdjeljenjeID,
                Rows = db.OdjeljenjeStavka.Where(x=>x.OdjeljenjeId== OdjeljenjeID).
                Select(a=>new StavkeIndexVM.Row
                    {
                        BrojUDnevniku = a.BrojUDnevniku,
                        BrojZakjucnihOcjena = db.DodjeljenPredmet.
                        Where(s=>s.OdjeljenjeStavka.UcenikId==a.UcenikId).Count(p=>p.ZakljucnoKrajGodine!=0),
                        StavkaId = a.Id,
                        Ucenik = a.Ucenik.ImePrezime
                    }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Obrisi(int StavkaId)
        {
            OdjeljenjeStavka os = db.OdjeljenjeStavka.Find(StavkaId);
            int osID = os.OdjeljenjeId;
            db.OdjeljenjeStavka.Remove(os);
            db.SaveChanges();
            return RedirectToAction("Index", new
            {
                odjeljenjeid = osID
            });
        }

        public IActionResult Dodaj(int odjeljenjeId)
        {
            StavkaDodajVM sd = new StavkaDodajVM();
            sd.StavkaId = 0;
            sd.brUDnevniku = db.OdjeljenjeStavka.Count(x => x.OdjeljenjeId == odjeljenjeId) + 1;
            sd.OdjeljenjeId = odjeljenjeId;
            sd.stavkeUcenici = db.Ucenik.Select(y => new SelectListItem
            {
                Value = y.Id.ToString(),
                Text = y.ImePrezime
            }).ToList();
            return PartialView(sd);
        }

        public IActionResult Snimi(StavkaDodajVM sd)
        {
            var os = new OdjeljenjeStavka();
            os.OdjeljenjeId = sd.OdjeljenjeId;
            os.BrojUDnevniku = sd.brUDnevniku;
            os.UcenikId = sd.UcenikId;
            db.OdjeljenjeStavka.Add(os);
            db.SaveChanges();
            return RedirectToAction("Index", new {odjeljenjeid = sd.OdjeljenjeId});
        }
    }
}