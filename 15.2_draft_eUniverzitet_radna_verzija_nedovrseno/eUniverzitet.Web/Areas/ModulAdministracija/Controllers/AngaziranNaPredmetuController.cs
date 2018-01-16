using System;
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
    public class AngaziranNaPredmetuController : Controller
    {
        private MojContext ctx;

        public AngaziranNaPredmetuController(MojContext ctx)
        {
            this.ctx = ctx;
        }

        public ActionResult Index(int izvodjenjePredmetaId)
        {
            IzvodjenjePredmeta predmet = ctx.IzvodjenjePredmetas.Where(x => x.Id == izvodjenjePredmetaId)
                .Include(x => x.Predmet.Npp.Odsjek.Fakultet)
            .Single();

            List<AngaziranNaPredmetuIndexVM.NastavnoOsobljeInfo> predajeList = ctx.AngaziranNaPredmets
                .Where(x => x.IzvodjenjePredmetaId == izvodjenjePredmetaId)
                .Select(x => new AngaziranNaPredmetuIndexVM.NastavnoOsobljeInfo
                {
                    Id = x.Id,
                    ImeIPrezime = x.NastavnoOsoblje.Zaposlenik.Korisnik.Ime + " " + x.NastavnoOsoblje.Zaposlenik.Korisnik.Prezime,
                    Uloga = x.AngaziranNaPredmetTip,
                    Zvanje = x.NastavnoOsoblje.NastavnoOsobljeZvanje
                    
                  }).ToList();

            AngaziranNaPredmetuIndexVM model = new AngaziranNaPredmetuIndexVM
            {
                TabelaPodaci =  predajeList,
                IzvodjenjePredmetaId = izvodjenjePredmetaId,
            };


            return View("Index", model);
        }

        public ActionResult Obrisi(int angaziranNaPredmetId)
        {
            AngaziranNaPredmet x = ctx.AngaziranNaPredmets.Find(angaziranNaPredmetId);
            ctx.AngaziranNaPredmets.Remove(x);
            ctx.SaveChanges();

            return RedirectToAction("Index", new { izvodjenjePredmetaId = x.IzvodjenjePredmetaId });
        }

        public ActionResult Dodaj(int izvodjenjePredmetaId)
        {
            AngaziranNaPredmetuUrediVM model = new AngaziranNaPredmetuUrediVM
            {
                IzvodjenjePredmetaId = izvodjenjePredmetaId,
                AngaziranNaPredmetTipStavke = AngaziranNaPredmetTipStavke(),
                NastavnoOsobljeStavke = NastavnoOsobljeStavke(),
            };

            return View("Uredi", model);
        }

        public ActionResult Uredi(int angaziranNaPredmetId)
        {
            AngaziranNaPredmet angaziranNaPredmet = ctx.AngaziranNaPredmets
                    .Where(x => x.Id == angaziranNaPredmetId)
                    .Include(x=>x.IzvodjenjePredmeta.Predmet.Npp.Odsjek.Fakultet)
                    .Single();

            AngaziranNaPredmetuUrediVM Model = new AngaziranNaPredmetuUrediVM
            {
                Id = angaziranNaPredmet.Id,
                IzvodjenjePredmetaId = angaziranNaPredmet.IzvodjenjePredmetaId,
                AngaziranNaPredmetTipStavke = AngaziranNaPredmetTipStavke(),
                NastavnoOsobljeStavke = NastavnoOsobljeStavke(),

                AngaziranNaPredmetTip = angaziranNaPredmet.AngaziranNaPredmetTip,
                NastavnoOsobljeId = angaziranNaPredmet.NastavnoOsobljeId
            };

            return View(Model);
        }

        public ActionResult Snimi(AngaziranNaPredmetuUrediVM input)
        {
            AngaziranNaPredmet entity;
            if (input.Id == 0)
            {
                entity = new AngaziranNaPredmet();
                ctx.AngaziranNaPredmets.Add(entity);
            }
            else
            {
                entity = ctx.AngaziranNaPredmets.Find(input.Id);
            }
            entity.AngaziranNaPredmetTip = input.AngaziranNaPredmetTip.Value;
            entity.NastavnoOsobljeId = input.NastavnoOsobljeId.Value;

            entity.IzvodjenjePredmetaId = input.IzvodjenjePredmetaId;
            
            ctx.SaveChanges();

            return RedirectToAction("Index", new { izvodjenjePredmetaId = input.IzvodjenjePredmetaId });
        }

        private List<SelectListItem> AngaziranNaPredmetTipStavke()
        {
            return Enum.GetValues(typeof(AngaziranNaPredmetTip))
                .Cast<AngaziranNaPredmetTip>()
                .Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() })
                .ToList();
        }

        private List<SelectListItem> NastavnoOsobljeStavke()
        {
            return ctx.NastavnoOsobljes
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Zaposlenik.Korisnik.Prezime + " " + x.Zaposlenik.Korisnik.Ime
                })
                .ToList();
        }
    }
}