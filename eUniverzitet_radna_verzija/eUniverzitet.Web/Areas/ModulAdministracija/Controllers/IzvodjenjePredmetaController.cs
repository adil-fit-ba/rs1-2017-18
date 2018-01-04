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
    public class IzvodjenjePredmetaController : Controller
    {
        private MojContext ctx;

        public IzvodjenjePredmetaController(MojContext ctx)
        {
            this.ctx = ctx;
        }

        public ActionResult Index(int predmetId)
        {
            Predmet predmet = ctx.Predmets.Where(x => x.Id == predmetId)
                .Include(x => x.Npp)
                .Include(x => x.Npp.Odsjek)
                .Include(x => x.Npp.Odsjek.Fakultet)
            .Single();

            List<IzvodjenjePredmetaIndexVM.IzvodjenjeInfo> predajeList = ctx.IzvodjenjePredmetas
                .Where(x => x.PredmetId == predmetId)
                .Select(x => new IzvodjenjePredmetaIndexVM.IzvodjenjeInfo
                {
                    Id = x.Id,
                    AkademskaGodina = x.AkademskaGodina.Opis,
                    AngaziranoNastavnoOsoblje = ctx.AngaziranNaPredmets.Where(a=>a.IzvodjenjePredmetaId == x.Id).Select(a=>new IzvodjenjePredmetaIndexVM.NastavnoOsobljeInfo
                    {
                        ImeIPrezime = a.NastavnoOsoblje.Zaposlenik.Korisnik.Ime + " " + a.NastavnoOsoblje.Zaposlenik.Korisnik.Prezime,
                        Zvanje = a.NastavnoOsoblje.NastavnoOsobljeZvanje.ToString(),
                        Uloga = a.AngaziranNaPredmetTip.ToString()
                    }).ToList()
                  }).ToList();

            IzvodjenjePredmetaIndexVM model = new IzvodjenjePredmetaIndexVM
            {
                TabelaPodaci =  predajeList,
                PredmetId = predmet.Id,
                PredmetNaziv = predmet.Naziv
            };



            return View("Index", model);
        }

        public ActionResult Obrisi(int izvodjenjePredmetaId)
        {
            IzvodjenjePredmeta x = ctx.IzvodjenjePredmetas.Find(izvodjenjePredmetaId);
            ctx.IzvodjenjePredmetas.Remove(x);
            ctx.SaveChanges();

            return RedirectToAction("Index", new { predmetId = x.PredmetId });
        }

        public ActionResult Dodaj(int predmetId)
        {
            IzvodjenjePredmetaUrediVM model = new IzvodjenjePredmetaUrediVM
            {
                AkademskeGodineStavke = AkademskaGodinaStavke(),
                PredmetId = predmetId,
                PredmetNaziv = ctx.Predmets.Find(predmetId).Naziv
            };

            return View("Uredi", model);
        }

        public ActionResult Uredi(int izvodjenjePredmetaId)
        {
            IzvodjenjePredmeta izvodjenjePredmeta = ctx.IzvodjenjePredmetas
                    .Where(x => x.Id == izvodjenjePredmetaId)
                    .Include(x=>x.Predmet.Npp.Odsjek.Fakultet)
                    .Single();

            Predmet predmet = izvodjenjePredmeta.Predmet;

            IzvodjenjePredmetaUrediVM Model = new IzvodjenjePredmetaUrediVM
            {
                Id = izvodjenjePredmeta.Id,
              
                AkademskaGodinaId = izvodjenjePredmeta.AkademskaGodinaId,
                AkademskeGodineStavke = AkademskaGodinaStavke(),

                PredmetId = predmet.Id,
                PredmetNaziv = predmet.Naziv
            };

            return View(Model);
        }

        public ActionResult Snimi(IzvodjenjePredmetaUrediVM input)
        {
            IzvodjenjePredmeta izvodjenjePredmetaDb;
            if (input.Id == 0)
            {
                izvodjenjePredmetaDb = new IzvodjenjePredmeta();
                ctx.IzvodjenjePredmetas.Add(izvodjenjePredmetaDb);
            }
            else
            {
                izvodjenjePredmetaDb = ctx.IzvodjenjePredmetas.Find(input.Id);
            }
            izvodjenjePredmetaDb.PredmetId = input.PredmetId;
            izvodjenjePredmetaDb.AkademskaGodinaId = input.AkademskaGodinaId;
            ctx.SaveChanges();

            return RedirectToAction("Index", new { predmetId = input.PredmetId });
        }

        private List<SelectListItem> AkademskaGodinaStavke()
        {
            return ctx.AkademskaGodinas
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Opis
                })
                .ToList();
        }
    }
}