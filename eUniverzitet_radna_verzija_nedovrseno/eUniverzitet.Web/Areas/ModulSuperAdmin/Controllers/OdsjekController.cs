using System.Collections.Generic;
using System.Linq;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas.ModulSuperAdmin.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Controllers
{
    [Area(MyAreaNames.ModulSuperAdmin)]
    [Autorizacija(KorisnickaUloga.SuperAdministrator)]
    public class OdsjekController : Controller
        {
            private MojContext ctx;

            public OdsjekController(MojContext ctx)
            {
                this.ctx = ctx;
            }

            public ActionResult Index(int fakultetId)
        {
            Fakultet fakultet = ctx.Fakultets.Find(fakultetId);

            List<OdsjekIndexVM.OdsjekInfo> smjerovi = (ctx.Odsjeks
                .Where(x => x.FakultetId == fakultetId)
                .Include(x => x.Fakultet)
                .Select(x => new OdsjekIndexVM.OdsjekInfo
                {
                    Id = x.Id,
                    OdsjekNaziv = x.Naziv,
                    BrojStudenata = ctx.Studiranjes.Count(s => s.Npp.OdsjekId == x.Id)
                }))
                .ToList();

            OdsjekIndexVM model = new OdsjekIndexVM
            {
                TabelaPodaci = smjerovi,
                FakultetId = fakultetId,
                FakultetNaziv = fakultet.Naziv
            };

            return View(model);
        }

        public ActionResult Dodaj(int fakultetId)
        {
            Fakultet fakultet = ctx.Fakultets.Find(fakultetId);

            OdsjekUrediVM model = new OdsjekUrediVM
            {
                FakultetId = fakultetId,
                FakultetNaziv = fakultet.Naziv
            };

            return View("Uredi", model);
        }

        public ActionResult Uredi(int smjerId)
        {
            Odsjek odsjek = ctx.Odsjeks
                .Where(x=>x.Id == smjerId)
                .Include(x=>x.Fakultet).Single();

            OdsjekUrediVM model = new OdsjekUrediVM
            {
                Id = odsjek.Id,
                OdjsekNaziv = odsjek.Naziv,
                FakultetNaziv = odsjek.Fakultet.Naziv,
                FakultetId = odsjek.FakultetId,
            };

            return View(model);
        }

        public ActionResult Snimi(OdsjekUrediVM input)
        {
            Odsjek odsjek;
            if (input.Id == 0)
            {
                odsjek = new Odsjek();
                ctx.Odsjeks.Add(odsjek);
            }
            else
            {
                odsjek = ctx.Odsjeks.Find(input.Id);
            }
            odsjek.Naziv = input.OdjsekNaziv;
            odsjek.FakultetId = input.FakultetId;

            ctx.SaveChanges();

            return RedirectToAction("Index", new {fakultetId = input.FakultetId });
        }

        public ActionResult Obrisi(int smjerId)
        {
            Odsjek smjer = ctx.Odsjeks.Find(smjerId);
            ctx.Odsjeks.Remove(smjer);
            ctx.SaveChanges();

            return RedirectToAction("Index", new { fakultetId = smjer.FakultetId });
        }
    }
}