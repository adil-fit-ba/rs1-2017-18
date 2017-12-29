using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class StavkeController : Controller
    {
        public IActionResult Index(int odjeljenjeid)
        {

            return PartialView();
        }
    }
}