using System;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Areas.ModulStudenti.Controllers
{
    [Area(MyAreaNames.ModulStudenti)]
    [Autorizacija(KorisnickaUloga.Student)]
    public class HomeController : Controller
    {
        // GET: ModulStudenti/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OdabirStudiranje(int studiranjeId)
        {
            throw new NotImplementedException();
        }
    }
}