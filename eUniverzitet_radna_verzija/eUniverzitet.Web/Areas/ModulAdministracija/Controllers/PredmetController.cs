using System.Collections.Generic;
using System.Linq;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas.ModulAdministracija.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Controllers
{
   [Autorizacija(_uloga = new []{KorisnickaUloga.AdministratorInstitucije})]
   [Area(MyAreaNames.ModulAdministracija)]
    public class PredmetController : Controller
    {

        private MojContext ctx;

        public PredmetController(MojContext ctx)
        {
            this.ctx = ctx;
        }

        public ActionResult Index(int nppId)
        {
            NPP npp = ctx.NPPs.Where(x => x.Id == nppId)
             .Include(x => x.Odsjek.Fakultet)
             .Include(x => x.AkademskaGodina)
             .SingleOrDefault();


            List<PredmetIndexVM.PredmetInfo> predmeti = (ctx.Predmets
                .Where(x => x.NppId == nppId)
                .Select(x => new PredmetIndexVM.PredmetInfo
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Ects = x.Ects,
                    GodinaStudija = x.GodinaStudija,
                    NppId = x.NppId
                }))
                .ToList();

            PredmetIndexVM model = new PredmetIndexVM
            {
                TabelaPodaci = predmeti,
                FakultetNaziv = npp.Odsjek.Fakultet.Naziv,
                OdsjekNaziv = npp.Odsjek.Naziv,
                NppNaziv = npp.AkademskaGodina.Opis + ": " + npp.Naziv,
                NppId = nppId,
            };

            return View(model);
        }

        public ActionResult Dodaj(int nppId)
        {
            PredmetUrediVM model = new PredmetUrediVM
            {
                NppId = nppId,
                GodinaStudijaStavke = GodinaStudijaStavke()
            };

            return View("Uredi", model);
        }

       

        public ActionResult Uredi(int predmetId)
        {
            Predmet entity = ctx.Predmets.Where(x => x.Id == predmetId)
             .Include(x => x.Npp.Odsjek.Fakultet)
             .Include(x => x.Npp.AkademskaGodina)
             .Single();

            PredmetUrediVM model = new PredmetUrediVM
            {
                Id = entity.Id,
                PredmetNaziv = entity.Naziv,
                Ects = entity.Ects,
                GodinaStudija = entity.GodinaStudija,

                NppId = entity.Npp.Id,
                GodinaStudijaStavke = GodinaStudijaStavke()
            };

            return View(model);
        }

        public ActionResult Snimi(PredmetUrediVM input)
        {
            Predmet entity;
            if (input.Id == 0)
            {
                entity = new Predmet();
                ctx.Predmets.Add(entity);
            }
            else
            {
                entity = ctx.Predmets.Find(input.Id);
            }
            entity.Naziv = input.PredmetNaziv;
            entity.NppId = input.NppId;
            entity.GodinaStudija = input.GodinaStudija;
            entity.Ects = input.Ects;

            ctx.SaveChanges();

            return RedirectToAction("Index", new { nppId = entity.NppId});
        }

        public ActionResult Obrisi(int predmetId)
        {
            Predmet entity = ctx.Predmets.Find(predmetId);
            ctx.Predmets.Remove(entity);
            ctx.SaveChanges();

            return RedirectToAction("Index", new { nppId = entity.NppId });
        }



        private List<SelectListItem> GodinaStudijaStavke()
        {
            List<SelectListItem> data = new List<SelectListItem>
            {
                new SelectListItem{Value = null, Text = "(odaberite Godinu studija)"},
                new SelectListItem{Value = "1", Text = "1"},
                new SelectListItem{Value = "2", Text = "2"},
                new SelectListItem{Value = "3", Text = "3"},
                new SelectListItem{Value = "4", Text = "4"},
            };

            return data;
        }
    }
}