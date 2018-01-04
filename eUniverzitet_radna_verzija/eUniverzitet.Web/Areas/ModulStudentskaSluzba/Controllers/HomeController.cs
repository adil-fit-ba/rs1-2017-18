using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Controllers
{
    [Area(MyAreaNames.ModulStudentskaSluzba)]
    [Autorizacija(KorisnickaUloga.StudentskaSluzba)]
    public class HomeController : Controller
    {
        // GET: ModulAdministracija/HomeAdministracija
        public ActionResult Index()
        {
            return View();
        }

        
    }
}