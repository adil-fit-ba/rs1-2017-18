using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas.ModulSuperAdmin.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Controllers
{
    [Area(MyAreaNames.ModulSuperAdmin)]
    [Autorizacija(KorisnickaUloga.SuperAdministrator)]
    public class OrganizacionaJedinicaController : Controller
    {
        private MojContext ctx;

        public OrganizacionaJedinicaController(MojContext ctx)
        {
            this.ctx = ctx;
        }

        public ActionResult Index()
        {
            List<OrganizacionaJedinicaIndexVM.Info> podaci =
                ctx.OrganizacionaJedinicas.AsEnumerable().Select(x => new OrganizacionaJedinicaIndexVM.Info
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Tip = x.OrganizacionaJedinicaTip
                }).ToList();

            OrganizacionaJedinicaIndexVM model = new OrganizacionaJedinicaIndexVM
            {
                TabelaPodaci = podaci
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            OrganizacionaJedinicaUrediVM model = new OrganizacionaJedinicaUrediVM
            {
                TipStavke = TipStavke(),
                NaucnaOblastStavke = NaucnaOblastStavke()
            };
            return View("Uredi", model);
        }

        private static List<SelectListItem> TipStavke()
        {
            return Enum.GetValues(typeof (OrganizacionaJedinicaTip))
                .Cast<OrganizacionaJedinicaTip>()
                .Select(x => new SelectListItem {Value = x.ToString(), Text = x.ToString()})
                .ToList();
        }

        private List <SelectListItem> NaucnaOblastStavke()
        {
            return ctx.NaucnaOblasts.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Opis}).ToList();
        }

        public ActionResult Uredi(int organizacionaJedinicaId)
        {
            OrganizacionaJedinica jedinica = ctx.OrganizacionaJedinicas.Single(x => x.Id == organizacionaJedinicaId);

            return View(new OrganizacionaJedinicaUrediVM
            {
                Id = jedinica.Id,
                Opis = jedinica.Naziv,
                Tip = jedinica.OrganizacionaJedinicaTip,
                TipStavke = TipStavke(),
                NaucnaOblastId = jedinica.Fakultet != null? jedinica.Fakultet.NaucnaOblastId:(int?) null,
            });
        }



        public ActionResult Snimi(OrganizacionaJedinicaUrediVM input)
        {
            OrganizacionaJedinica x;
            if (input.Id == 0)
            {
                switch (input.Tip)
                {
                    case OrganizacionaJedinicaTip.Fakultet:
                        x = new Fakultet();
                        x.Fakultet.NaucnaOblastId = input.NaucnaOblastId.Value;
                        break;
                    case OrganizacionaJedinicaTip.Institut:
                        x = new Fakultet();
                        break;
                    case OrganizacionaJedinicaTip.Rektorat:
                        x = new Fakultet();
                        break;
                    default:
                        throw new HttpRequestException("Bad Request");
                }
             
                ctx.OrganizacionaJedinicas.Add(x);
                
            }
            else
            {
                x = ctx.OrganizacionaJedinicas.Find(input.Id);
            }
            x.Naziv = input.Opis;
          

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Obrisi(int organizacionaJedinicaId)
        {
            OrganizacionaJedinica x = ctx.OrganizacionaJedinicas.Find(organizacionaJedinicaId);
            ctx.OrganizacionaJedinicas.Remove(x);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}