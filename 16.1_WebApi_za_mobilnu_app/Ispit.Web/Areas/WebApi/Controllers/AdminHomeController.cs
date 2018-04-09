using System;
using System.Collections.Generic;
using System.Linq;
using eUniverzitet.Web.Helper;
using Ispit.Data;
using Ispit.Web.Areas.WebApi.ViewModels;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Web.Areas.WebApi.Controllers
{
    [Area("WebApi")]
    public class AdminHomeController : Controller
    {
        private MyContext _context;

        public AdminHomeController(MyContext context)
        {
            _context = context;
        }

        public string Index()
        {
            return "Hello, Ucenik " + HttpContext.GetLogiraniKorisnik().KorisnickoIme;
        }

        public ApiResult<AdminOdjeljenjaVM> Predmeti(int? razred)
        {
            if (new Random().Next(3)==0)
                return ApiResult<AdminOdjeljenjaVM>.Error(12345, "Greška. Metodom slučajnog odabira ne možete pristupiti sistemu.");


            var model = new AdminOdjeljenjaVM
            {
                rows = _context.Odjeljenje.Select(x => new AdminOdjeljenjaVM.Row
                {
                    OdeljenjeId = x.Id,
                    SkolskaGodina = x.SkolskaGodina,
                    Razrednik = x.Razrednik.ImePrezime,
                    Oznaka = x.Oznaka,
                    Razred = x.Razred
                }).ToList()
            };


            return ApiResult<AdminOdjeljenjaVM>.OK(model);
        }

    }
}