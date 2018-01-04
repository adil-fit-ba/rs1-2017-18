using System.Collections.Generic;
using System.Linq;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas.ModulSuperAdmin.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Controllers
{
    [Area(MyAreaNames.ModulSuperAdmin)]
    [Autorizacija( KorisnickaUloga.SuperAdministrator )]
    public class AkademskaGodinaController : Controller
        {
            private MojContext ctx;

            public AkademskaGodinaController(MojContext ctx)
            {
                this.ctx = ctx;
            }

            public ActionResult Index()
        {
            List<AkademskaGodinaIndexVM.AkademskaGodinaInfo> akademskaGodinaInfos = ctx.AkademskaGodinas.Select(x => new AkademskaGodinaIndexVM.AkademskaGodinaInfo
            {
                Id = x.Id,
                Opis = x.Opis
            }).ToList();

            AkademskaGodinaIndexVM model = new AkademskaGodinaIndexVM
            {
                TabelaPodaci = akademskaGodinaInfos
            };
            return View(model);
        }

         public ActionResult Dodaj()
        {
            AkademskaGodinaUrediVM model = new AkademskaGodinaUrediVM();

            return View("Uredi", model);
        }

        public ActionResult Uredi(int id)
        {
            AkademskaGodinaUrediVM model = ctx.AkademskaGodinas
                .Where(x => x.Id == id)
                .Select(x => new AkademskaGodinaUrediVM
                {
                    Id = x.Id,
                    Opis = x.Opis
            }).Single();

            return View(model);
        }

        public ActionResult Snimi(AkademskaGodinaUrediVM input)
        {
            AkademskaGodina entity;
            if (input.Id == 0)
            {
                entity = new AkademskaGodina();
                ctx.AkademskaGodinas.Add(entity);
            }
            else
            {
                entity = ctx.AkademskaGodinas.Find(input.Id);
            }
            entity.Opis = input.Opis;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Obrisi(int id)
        {
            AkademskaGodina x = ctx.AkademskaGodinas.Find(id);
            ctx.AkademskaGodinas.Remove(x);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}