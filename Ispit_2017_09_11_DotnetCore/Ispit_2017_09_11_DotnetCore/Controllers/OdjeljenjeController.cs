using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class OdjeljenjeController : Controller
    {
        private MojContext _context;

        public OdjeljenjeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            OdjeljenjeIndexVM o = new OdjeljenjeIndexVM();
            o.Rows = _context.Odjeljenje
                .Select(x => new OdjeljenjeIndexVM.Row
                {
                    OdjeljenjeID = x.Id,
                    SkolskaGodina = x.SkolskaGodina,
                    Razred = x.Razred,
                    Oznaka = x.Oznaka,
                    Razrednik = x.Nastavnik.ImePrezime,
                    Prebacen = x.IsPrebacenuViseOdjeljenje,
                    NajboljiUcenik = _context.DodjeljenPredmet
                    .Average(a=>a.ZakljucnoKrajGodine ).ToString()
                }).ToList();
            return View();
        }

        public IActionResult Dodaj()
        {
            return View();
        }
    }
}