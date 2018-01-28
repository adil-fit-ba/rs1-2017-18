using System.Web.Mvc;

namespace RS1.Ispit.Web.Controllers
{
    public class AjaxTestController : Controller
    {
        // GET: AjaxTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxTestAction()
        {
            return View("_AjaxTestView");
        }
    }
}