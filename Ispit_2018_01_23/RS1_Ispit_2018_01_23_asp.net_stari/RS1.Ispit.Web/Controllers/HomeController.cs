using System.Web.Mvc;
using RS1.Ispit.Web.EF;

namespace RS1.Ispit.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult TestDB()
        {
            return View(new MojContext());
        }

    }
}