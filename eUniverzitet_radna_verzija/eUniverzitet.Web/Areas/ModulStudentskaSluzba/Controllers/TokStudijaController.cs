using System.Linq;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models;
using eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models.TokStudija;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Controllers
{
    [Area(MyAreaNames.ModulStudentskaSluzba)]
    [Autorizacija(KorisnickaUloga.StudentskaSluzba)]
    public class TokStudijaController : Controller
    {
        private MojContext ctx;

        public TokStudijaController(MojContext ctx)
        {
            this.ctx = ctx;
        }

        public ActionResult SnimiUpisGodine(UpisGodineDetaljnoVM input)
        {
            UpisGodine x = ctx.UpisGodines.Single(z => z.Id == input.Id);
            x.Datum1_ZimskiUpis = input.Datum1_ZimskiUpis;
            x.Datum2_ZimskiOvjera = input.Datum2_ZimskiOvjera;
            x.Datum3_LjetniUpis = input.Datum3_LjetniUpis;
            x.Datum4_LjetniOvjera = input.Datum4_LjetniOvjera;
            x.GodinaStudija = input.GodinaStudija;
            x.AkademskaGodinaId = input.AkademskaGodinaId;
            x.Cijena = input.Cijena;

            ctx.SaveChanges();

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Index(int studentiranjeId, int? upisGodineId, int? uplataId, int? slusaPredmetId)
        {
            TokStudijaIndexVM model = new TokStudijaIndexVM();

            model.OpsteInfo = ctx.Studiranjes.Where(x => x.Id == studentiranjeId)
                .Select(x => new OpsteInfoVM
                {
                    StudentId = x.Student.Id,
                    Ime = x.Student.Korisnik.Ime,
                    OpstinaPrebivalista = x.Student.OpstinaPrebivalista.Opis,
                    OpstinaRodjenja = x.Student.OpstinaRodjenja.Opis,
                    Prezime = x.Student.Korisnik.Prezime,
                    BrojIndeksa = x.BrojIndeksa,
                    NPP = x.Npp.Naziv,
                    Odsjek = x.Npp.Odsjek!=null?x.Npp.Odsjek.Naziv:"",
                    Fakultet = x.Npp.Fakultet.Naziv
                }).Single();


            model.UpisaneGodine = ctx.UpisGodines
                .Where(x => x.StudiranjeId == studentiranjeId)
                .Select(x => new UpisaneGodineVM
                {
                    Id = x.Id,
                    StudiranjeId = x.StudiranjeId,
                    GodinaStudija = x.GodinaStudija,
                    Cijena = x.Cijena,
                    PolozenoPredmeta =
                        ctx.SlusaPredmets.Where(y => y.UpisGodineId == x.Id).Count(z => z.FinalnaOcjena > 5),
                    Datum1_ZimskiUpis = x.Datum1_ZimskiUpis,
                    Datum2_ZimskiOvjera = x.Datum2_ZimskiOvjera,
                    Datum3_LjetniUpis = x.Datum3_LjetniUpis,
                    Datum4_LjetniOvjera = x.Datum4_LjetniOvjera
                })
                .ToList();

            model.SlusaPredmete = ctx.SlusaPredmets
                .Where(x => x.UpisGodine.StudiranjeId == studentiranjeId)
                .Select(x => new SlusaPredmeteVM
                {
                    DatumOcjene = x.DatumOcjene,
                    ECTS = x.IzvodjenjePredmeta.Predmet.Ects,
                    GodinaStudija = x.UpisGodine.GodinaStudija,
                    NazivPredmeta = x.IzvodjenjePredmeta.Predmet.Naziv,
                    Ocjena = x.FinalnaOcjena
                }).ToList();

            model.Uplate = ctx.UplataStudijas
                    .Where(x => x.UpisGodine.StudiranjeId == studentiranjeId)
                    .Select(x => new UplataVM
                    {
                        DatumUplate = x.DatumUplate,
                        EvidentiranoDatum = x.EvidentiranoDatum,
                        EvidentiranoKorisnik = x.EvidentiranoKorisnik.Ime + " " + x.EvidentiranoKorisnik.Prezime,
                        Iznos = x.Iznos,
                        Svrha = x.Svrha
                    })
                    .ToList();


            if (upisGodineId.HasValue)
                model.UpisGodineDetaljno = ctx.UpisGodines.Where(z => z.Id == upisGodineId)
                    .Select(x => new UpisGodineDetaljnoVM
                    {
                        Id = x.Id,
                        AkademskaGodinaId = x.AkademskaGodinaId,
                        GodinaStudija = x.GodinaStudija,
                        Datum1_ZimskiUpis = x.Datum1_ZimskiUpis,
                        Datum2_ZimskiOvjera = x.Datum2_ZimskiOvjera,
                        Datum3_LjetniUpis = x.Datum3_LjetniUpis,
                        Datum4_LjetniOvjera = x.Datum4_LjetniOvjera,
                        AkademskaGodinaOptions = ctx.AkademskaGodinas.Select(y => new SelectListItem { Value = y.Id.ToString(), Text = y.Opis })
                    }).Single();

            return View(model);
        }

       

    }
}