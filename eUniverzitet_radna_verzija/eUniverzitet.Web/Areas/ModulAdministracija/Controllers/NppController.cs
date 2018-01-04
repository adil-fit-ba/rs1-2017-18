using System.Collections.Generic;
using System.Linq;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas.ModulAdministracija.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Controllers
{
    [Area(MyAreaNames.ModulAdministracija)]
    [Autorizacija(KorisnickaUloga.SuperAdministrator, KorisnickaUloga.AdministratorInstitucije)]
    public class NppController : Controller
     {
         private MojContext ctx;

         public NppController(MojContext ctx)
         {
             this.ctx = ctx;
         }

         public ActionResult Index(int odsjekId)
        {
            Odsjek odsjek = ctx.Odsjeks.Where(x => x.Id == odsjekId).Include(x => x.Fakultet).Single();

            List<NppIndexVM.NppInfo> nppInfos = (ctx.NPPs
                .Where(x => x.OdsjekId == odsjekId)
                .Select(x => new NppIndexVM.NppInfo()
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    AkademskaGodina = x.AkademskaGodina.Opis,

                   
                }))
                .ToList();

            NppIndexVM model = new NppIndexVM
            {
                TabelaPodaci = nppInfos, 
                FakultetNaziv = odsjek.Fakultet.Naziv,
                OdsjekNaziv = odsjek.Naziv,
                OdsjekId= odsjek.Id,
            };

            return View(model);
        }

        public ActionResult Dodaj(int odsjekId)
        {
            Odsjek odsjek = ctx.Odsjeks.Where(x => x.Id == odsjekId).Include(x => x.Fakultet).Single();

            NppUrediVM model = new NppUrediVM
            {
                AkademskaGodinaStavke = AkademskaGodinaStavke(),
                FakultetId = odsjek.FakultetId,
                OdsjekId = odsjek.Id,
            };

            return View("Uredi", model);
        }

        public ActionResult Uredi(int nppId)
        {
            NPP npp = ctx.NPPs.Where(x=>x.Id == nppId).Include(x=>x.Odsjek.Fakultet).Single();
            Odsjek odsjek = npp.Odsjek;

            NppUrediVM model = new NppUrediVM
            {
                Id = npp.Id,
                Naziv = npp.Naziv,
                AkademskaGodinaId = npp.AkademskaGodinaId,
                AkademskaGodinaStavke = AkademskaGodinaStavke(),
                FakultetId = npp.FakultetId,
                OdsjekId = odsjek.Id,
            };

            return View(model);
        }

        public ActionResult Snimi(NppUrediVM input)
        {
            NPP entity;
            if (input.Id == 0)
            {
                entity = new NPP();
                ctx.NPPs.Add(entity);
            }
            else
            {
                entity = ctx.NPPs.Find(input.Id);
            }
            entity.Naziv = input.Naziv;
            entity.FakultetId = input.FakultetId;
            entity.OdsjekId = input.OdsjekId;
            entity.AkademskaGodinaId = input.AkademskaGodinaId;

            ctx.SaveChanges();

            return RedirectToAction("Index", new { odsjekId = input.OdsjekId });
        }

        public ActionResult Obrisi(int id)
        {
            NPP npp = ctx.NPPs.Find(id);
            ctx.NPPs.Remove(npp);
            ctx.SaveChanges();

            return RedirectToAction("Index", new { odsjekId = npp.OdsjekId });
        }

       private List<SelectListItem> AkademskaGodinaStavke()
        {
            List<SelectListItem> data = new List<SelectListItem>();
            data.Add(new SelectListItem
            {
                Value = null,
                Text = "(odaberite akademsku godinu)"
            });

            data.AddRange(ctx.AkademskaGodinas
                .OrderBy(x => x.Opis)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Opis
                }).ToList());
            return data;
        }
    }
}