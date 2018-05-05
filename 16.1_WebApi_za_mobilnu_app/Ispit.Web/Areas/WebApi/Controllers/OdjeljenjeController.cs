﻿using System;
using System.Collections.Generic;
using System.Linq;
using eUniverzitet.Web.Helper;
using Ispit.Data;
using Ispit.Web.Areas.WebApi.ViewModels;
using Ispit.Web.Helper;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Web.Areas.WebApi.Controllers
{
    [Area("WebApi")]
    public class OdjeljenjeController : Controller
    {
        private MyContext _context;

        public OdjeljenjeController(MyContext context)
        {
            _context = context;
        }

        public string Proba()
        {
            return "Hello, Ucenik " + HttpContext.GetLogiraniKorisnik().KorisnickoIme;
        }

        public ApiResult<OdjeljenjeIndexVM> Index(int? razred)
        {
            if (new Random().Next(4)==0)
                return ApiResult<OdjeljenjeIndexVM>.Error(12345, "Greška. Metodom slučajnog odabira ne možete pristupiti sistemu.");


            var model = new OdjeljenjeIndexVM
            {
                rows = _context.Odjeljenje.Select(x => new OdjeljenjeIndexVM.Row
                {
                    OdeljenjeId = x.Id,
                    SkolskaGodina = x.SkolskaGodina,
                    Razrednik = x.Razrednik.ImePrezime,
                    Oznaka = x.Oznaka,
                    Razred = x.Razred,
                    RazrednikID = x.RazrednikID
                }).ToList()
            };


            return ApiResult<OdjeljenjeIndexVM>.OK(model);
        }

        public ApiResult<OdjeljenjeNastavniciVM> GetNastavnici()
        {

            var model = new OdjeljenjeNastavniciVM
            {

                texts = _context.Nastavnik.Select(x => x.ImePrezime).ToList(),
                iDs = _context.Nastavnik.Select(x => x.NastavnikID).ToList(),
        };
            

            return ApiResult<OdjeljenjeNastavniciVM>.OK(model);
        }
        public ApiResult<int> Save(OdjeljenjeSaveVM input)
        {
            if (new Random().Next(4) == 0)
                return ApiResult<int>.Error(12345, "Greška. Metodom slučajnog odabira ne možete pristupiti sistemu.");


            _context.Odjeljenje.Add(new Odjeljenje
            {
                Oznaka = input.Oznaka,
                IsPrebacenuViseOdjeljenje = false,
                SkolskaGodina = input.SkolskaGodina,
                RazrednikID = input.RazrednikID
            });

            _context.SaveChanges();
            return ApiResult<int>.OK(0);
        }

    }
}