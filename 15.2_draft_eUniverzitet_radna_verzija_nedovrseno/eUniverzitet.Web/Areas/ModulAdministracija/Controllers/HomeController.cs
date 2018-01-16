using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Controllers
{
    [Area(MyAreaNames.ModulAdministracija)]
    [Autorizacija(KorisnickaUloga.SuperAdministrator, KorisnickaUloga.AdministratorInstitucije)]
    public class HomeController : Controller
    {
        // GET: ModulAdministracija/HomeAdministracija
        public ActionResult Index()
        {
            return View();
        }
    }
}