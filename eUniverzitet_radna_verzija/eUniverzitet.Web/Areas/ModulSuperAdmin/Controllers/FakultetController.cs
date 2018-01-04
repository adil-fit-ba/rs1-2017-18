using System.Collections.Generic;
using System.Linq;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Areas;
using eUniverzitet.Web.Areas.ModulSuperAdmin.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Controllers
{
    

    [Area(MyAreaNames.ModulSuperAdmin)]
    [Autorizacija(KorisnickaUloga.SuperAdministrator)]
    public class FakultetController : Controller
    {
        private MojContext ctx;

        public FakultetController(MojContext ctx)
        {
            this.ctx = ctx;
        }

        public ActionResult Index()
        {
            List<FakultetIndexVM.Info> fakultetInfos = ctx.Fakultets.Select(x => new FakultetIndexVM.Info
            {
                Id = x.Id,
                Naziv = x.Naziv,
                BrojOdsjeka = ctx.Odsjeks.Count(y => y.FakultetId == x.Id),
                BrojStudenata = ctx.Studiranjes.Count(y => y.Npp.FakultetId == x.Id),
                NaucnaOblast = x.NaucnaOblast.Opis

            }).ToList();

            FakultetIndexVM model = new FakultetIndexVM
            {
                TabelaPodaci = fakultetInfos
            };
            return View(model);
        }
    }

}