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
    [Autorizacija(KorisnickaUloga.StudentskaSluzba)]
    public class StudentController : Controller
    {
        private MojContext ctx;

        public StudentController(MojContext ctx)
        {
            this.ctx = ctx;
        }

        [Autorizacija(KorisnickaUloga.SuperAdministrator, KorisnickaUloga.AdministratorInstitucije, KorisnickaUloga.StudentskaSluzba)]

        public ActionResult Index(int? fakultetId)
        {
            List<StudentIndexVM.StudentInfo> studentInfos = ctx.Students
                .Where(x => !x.Studiranjes.Any() ||  x.Studiranjes.Any(a => !fakultetId.HasValue || a.Npp.FakultetId == fakultetId))
                .Select(x => new StudentIndexVM.StudentInfo{
                    Id = x.Id,
                    Ime = x.Korisnik.Ime,
                    Prezime = x.Korisnik.Prezime,
                    DatumRodjenja = x.DatumRodjenja,
                    StudentiranjeInfos = x.Studiranjes.Select(s=>new StudentIndexVM.StudentiranjeInfo{
                            Id = s.Id,    
                            Fakultet = s.Npp.Fakultet.Naziv,
                            Odjsek = s.Npp.Odsjek!=null?s.Npp.Odsjek.Naziv:"",
                            Status = s.StudentiranjeStatus,
                            Pocetak = s.UgovorPocetak,
                            Kraj = s.UgovorKraj
                        }).ToList()
                }).ToList();

            StudentIndexVM Model = new StudentIndexVM 
            {
                TabelaPodaci = studentInfos, 
                 FakultetId = fakultetId,
                 FakultetStavke = FakultetStavke()
            };

            return View("Index", Model);
        }
        [Autorizacija(KorisnickaUloga.SuperAdministrator, KorisnickaUloga.AdministratorInstitucije, KorisnickaUloga.StudentskaSluzba)]

        private List<SelectListItem> FakultetStavke()
        {
            var smjerovi = new List<SelectListItem>();
            smjerovi.Add(new SelectListItem { Value = null, Text = "(svi fakulteti)" });

            smjerovi.AddRange(ctx.Fakultets
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());
            return smjerovi;
        }

      public ActionResult Obrisi(int studentId)
        {
            Student x = ctx.Students.Find(studentId);
            ctx.Students.Remove(x);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Dodaj(int korisnikId = 0)
        {
            StudentUrediVM Model = new StudentUrediVM();
            Model.KorisnikId = korisnikId;

            return View("Uredi", Model);
        }

        public ActionResult Uredi(int studentId)
        {
            Student student = ctx.Students
                .Where(x => x.Id == studentId)
                .Include(x => x.Korisnik)
                .Single();

            StudentUrediVM Model = new StudentUrediVM
            {
                Id = student.Id,
                KorisnikId = student.Korisnik.Id,
                Ime = student.Korisnik.Ime,
                Prezime = student.Korisnik.Prezime,
                KorisnickoIme = student.Korisnik.KorisnickoIme,
                Lozinka = student.Korisnik.Lozinka,
                DatumRodjenja = student.DatumRodjenja,
            };


            return View("Uredi", Model);
        }

        public ActionResult Snimi(StudentUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", vm);
            }

            Student entity;
            if (vm.Id == 0)
            {
                entity = new Student();
                if (vm.KorisnikId == 0)
                {
                    entity.Korisnik = new Korisnik();
                    ctx.Students.Add(entity);
                }
                else
                {
                    entity.Korisnik = ctx.Korisniks.Find(vm.KorisnikId);
                }
            }
            else
            {
                entity = ctx.Students
                    .Where(s => s.Id == vm.Id)
                    .Include(s => s.Korisnik)
                    .Single();
            }


            entity.Korisnik.Ime = vm.Ime;
            entity.Korisnik.Prezime = vm.Prezime;
            entity.Korisnik.KorisnickoIme = vm.KorisnickoIme;
            entity.Korisnik.Lozinka = vm.Lozinka;
            entity.DatumRodjenja = vm.DatumRodjenja;


            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

   
    }
}