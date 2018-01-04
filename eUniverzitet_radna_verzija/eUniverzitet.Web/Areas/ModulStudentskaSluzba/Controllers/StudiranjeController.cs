using System.Collections.Generic;
using System.Linq;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Controllers
{
    [Area(MyAreaNames.ModulStudentskaSluzba)]
    [Autorizacija( KorisnickaUloga.SuperAdministrator, KorisnickaUloga.AdministratorInstitucije, KorisnickaUloga.StudentskaSluzba)]
    public class StudiranjeController : Controller
  {
      private MojContext ctx;

      public StudiranjeController(MojContext ctx)
      {
          this.ctx = ctx;
      }

      public ActionResult Index(int? fakultetId)
        {
            IEnumerable<Zaposlenje> studentskeSlube = Autentifikacija.GetLogiraniKorisnik(HttpContext)
                    .Zaposlenik.Zaposlenja.Where(x => x.KorisnickaUloga == KorisnickaUloga.StudentskaSluzba || x.KorisnickaUloga == KorisnickaUloga.AdministratorInstitucije);

            if (!studentskeSlube.Any())
                return new UnauthorizedResult();


            if (!fakultetId.HasValue)
            {
                fakultetId = studentskeSlube.First().OrganizacionaJedinicaId;
            }
            else
            {
                if (studentskeSlube.All(x => x.OrganizacionaJedinicaId != fakultetId))
                    return new UnauthorizedResult();
            }

            

            List<StudiranjeIndexVM.StudiranjeInfo> studentInfos = ctx.Studiranjes
                .Where(x => x.Npp.FakultetId == fakultetId)
                .Select(x => new StudiranjeIndexVM.StudiranjeInfo
                {
                    BrojIndeksa = x.BrojIndeksa,
                    Fakultet_Naziv = x.Npp.Fakultet.Naziv,
                    Id = x.Id,
                    Ime = x.Student.Korisnik.Ime,
                    Prezime = x.Student.Korisnik.Prezime,
                    Odsjek_Naziv = x.Npp.Odsjek!=null?x.Npp.Odsjek.Naziv:"",
                    EctsUkupno =
                        ctx.SlusaPredmets.Where(y => y.UpisGodine.StudiranjeId == x.Id && y.FinalnaOcjena != null)
                            .Sum(z => (float?) z.IzvodjenjePredmeta.Predmet.Ects) ?? 0,
                    BrojPolozenihPredmeta =
                        ctx.SlusaPredmets.Count(y => y.UpisGodine.StudiranjeId == x.Id && y.FinalnaOcjena != null)
                })
                .ToList();

            StudiranjeIndexVM Model = new StudiranjeIndexVM 
            {
                TabelaPodaci = studentInfos, 
                OdsjekStavke = OdsjekStavke(),
                FakultetStavke = FakultetStavke()
            };

            return View("Index", Model);
        }

        public ActionResult Obrisi(int studentiranjeId)
        {
            Studiranje x = ctx.Studiranjes.Find(studentiranjeId);
            ctx.Studiranjes.Remove(x);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Dodaj()
        {
            StudiranjeUrediVM Model = new StudiranjeUrediVM();
            UcitajStavke(Model);

            return View("Uredi", Model);
        }

        public ActionResult Uredi(int studentiranjeId)
        {
            Studiranje student = ctx.Studiranjes
                .Where(x => x.Id == studentiranjeId)
                .Include(x => x.Student.Korisnik)
                .Single();

            StudiranjeUrediVM Model = new StudiranjeUrediVM
            {
                Id = student.Id,
                OdsjekId = student.Npp.OdsjekId,
                BrojIndeksa = student.BrojIndeksa,
            };

            UcitajStavke(Model);


            return View("Uredi", Model);
        }

        public ActionResult Snimi(StudiranjeUrediVM model)
        {
            if (!ModelState.IsValid)
            {
                UcitajStavke(model);

                return View("Uredi", model);
            }

            Studiranje entity;
            if (model.Id == 0)
            {
                entity = new Studiranje();
                entity.Student = new Student();
                entity.Student.Korisnik = new Korisnik();
                ctx.Studiranjes.Add(entity);
            }
            else
            {
                entity = ctx.Studiranjes
                    .Where(s => s.Id == model.Id)
                    .Include(s => s.Student.Korisnik)
                    .Single();
            }


            entity.BrojIndeksa = model.BrojIndeksa;
            entity.NppId = model.Npp.Value;


            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

      private void UcitajStavke(StudiranjeUrediVM model)
      {
          model.OdsjekStavke = OdsjekStavke();
          model.FakultetStavke = FakultetStavke();
          model.NppStavke = NppStavke();
      }

      private List<SelectListItem> OdsjekStavke()
        {
            var smjerovi = new List<SelectListItem>();
            smjerovi.Add(new SelectListItem {Value = null, Text = "(svi odjseci)"});

            smjerovi.AddRange(ctx.Odsjeks
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList());
            return smjerovi;
        }

        private List<SelectListItem> FakultetStavke()
        {
            var smjerovi = new List<SelectListItem>();
            smjerovi.Add(new SelectListItem { Value = null, Text = "(svi fakulteti)" });

            smjerovi.AddRange(ctx.Fakultets
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());
            return smjerovi;
        }

        private List<SelectListItem> NppStavke()
        {
            var smjerovi = new List<SelectListItem>();
            smjerovi.Add(new SelectListItem { Value = null, Text = "(svi npp)" });

            smjerovi.AddRange(ctx.NPPs
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());
            return smjerovi;
        }
    }
}