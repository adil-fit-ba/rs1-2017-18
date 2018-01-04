using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Controllers
{
    [Area(MyAreaNames.ModulSuperAdmin)]
    [Autorizacija( KorisnickaUloga.SuperAdministrator )]
    public class HomeController : Controller
    {
        // GET: ModulAdministracija/HomeAdministracija
        public ActionResult Index()
        {
            return View();
        }
    }
}