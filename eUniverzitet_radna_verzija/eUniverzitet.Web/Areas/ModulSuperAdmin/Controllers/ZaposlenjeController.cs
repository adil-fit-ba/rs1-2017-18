using System;
using System.Linq;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas.ModulSuperAdmin.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Controllers
{
    [Area(MyAreaNames.ModulSuperAdmin)]
    [Autorizacija(KorisnickaUloga.SuperAdministrator)]
    public class ZaposlenjeController : Controller
    {

        private MojContext ctx;

        public ZaposlenjeController(MojContext ctx)
        {
            this.ctx = ctx;
        }

        public ActionResult Index(int zaposlenikId)
        {
            ZaposlenjeIndexVM model = new ZaposlenjeIndexVM
            {
                TabelaPodaci = ctx.Zaposlenjes
                .Where(x=>x.ZaposlenikId == zaposlenikId)
                .Select(x => new ZaposlenjeIndexVM.ZaposlenjeInfo()
                {
                    Id = x.Id,
                  
                    OrganizacionaJedinica = x.OrganizacionaJedinica.Naziv,
                    RadnoMjesto = x.ZaposlenjeMjesto.Naziv,
                    DatumPocetak = x.UgovorPocetak,
                    KorisnickaUloga = x.KorisnickaUloga

              }).ToList(),

              ZaposlenikId = zaposlenikId,
            };


            return View(model);
        }


        public ActionResult Uredi(int zaposlenjeId)
        {
            ZaposlenjeUrediVM model =
                ctx.Zaposlenjes.Where(x => x.Id == zaposlenjeId).Select(x => new ZaposlenjeUrediVM
                {
                    Id = x.Id,
                    zaposlenikId = x.Zaposlenik.Id,
                    DatumPocetak = x.UgovorPocetak,
                    OrganizacionaJedinicaId = x.OrganizacionaJedinicaId,
                    KorisnickaUloga = x.KorisnickaUloga,
                    ZaposljenjeMjestoId = x.ZaposlenjeMjestoId

                }).Single();

            UcitajStavke(model);


            return View(model);
        }

        public ActionResult Obrisi(int zaposlenjeId)
        {
            Zaposlenje x = ctx.Zaposlenjes.Find(zaposlenjeId);
            int zaposlenikId = x.ZaposlenikId;

            ctx.Zaposlenjes.Remove(x);
            ctx.SaveChanges();


            return RedirectToAction("Index", new { zaposlenikId = zaposlenikId });
        }

        public ActionResult Dodaj(int zaposlenikId)
        {
            ZaposlenjeUrediVM Model = new ZaposlenjeUrediVM
            {
                zaposlenikId = zaposlenikId
            };
            UcitajStavke(Model);

            return View("Uredi", Model);
        }

        public ActionResult Snimi(ZaposlenjeUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                UcitajStavke(vm);

                return View("Uredi", vm);
            }

            Zaposlenje entity;
            if (vm.Id == 0)
            {
                entity = new Zaposlenje();
                ctx.Zaposlenjes.Add(entity);
            }
            else
            {
                entity = ctx.Zaposlenjes
                    .Where(s => s.Id == vm.Id)
                    .Include(s => s.Zaposlenik.Korisnik)
                    .Single();
            }

            entity.ZaposlenikId = vm.zaposlenikId;
            entity.UgovorPocetak = vm.DatumPocetak.Value;
            entity.UgovorKraj = vm.DatumKraj;
            entity.OrganizacionaJedinicaId = vm.OrganizacionaJedinicaId.Value;
            entity.ZaposlenjeMjestoId = vm.ZaposljenjeMjestoId.Value;
            entity.KorisnickaUloga = vm.KorisnickaUloga.Value;



            ctx.SaveChanges();

            return RedirectToAction("Index", new { zaposlenikId  = vm.zaposlenikId});
        }


        private void UcitajStavke(ZaposlenjeUrediVM model)
        {
            model.OrganizacionaJedinicaStavke = ctx.OrganizacionaJedinicas.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList();
            model.KorisnickaUlogaStavke = Enum.GetValues(typeof(KorisnickaUloga))
                .Cast<KorisnickaUloga>()
                .Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() })
                .ToList();
            model.ZaposlenjeMjestoStavke = ctx.ZaposlenjeMjestos.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList();
        }
    }
}