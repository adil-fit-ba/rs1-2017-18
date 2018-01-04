using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Areas.ModulEdukatori.Controllers
{
    [Area(MyAreaNames.ModulEdukatori)]
    [Autorizacija(KorisnickaUloga.Edukator)]
    public class HomeController : Controller
    {
        // GET: ModulEdukatori/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}