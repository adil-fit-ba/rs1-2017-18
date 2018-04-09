using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Ispit.Web.Helper;
using Ispit.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Web.Controllers
{
    [Autorizacija(ucenik: true, nastavnici: true)]
    public class SesijaController : Controller
    {
        private MyContext _db;

        public SesijaController(MyContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var kId = HttpContext.GetLogiraniKorisnik().Id;
            SesijaIndexVM model = new SesijaIndexVM();
            model.Rows = _db.AutorizacijskiToken
                .Where(x=>x.KorisnickiNalogId == kId)
                .Select(s => new SesijaIndexVM.Row
            {
                VrijemeLogiranja = s.VrijemeEvidentiranja,
                token = s.Vrijednost,
                IpAdresa = s.IpAdresa
            }).ToList();
            model.TrenutniToken = HttpContext.GetTrenutniToken();
            return View(model);
        }

        public IActionResult Obrisi(string token)
        {
            AutorizacijskiToken obrisati =_db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == token);
            if (obrisati != null)
            {
                _db.AutorizacijskiToken.Remove(obrisati);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}