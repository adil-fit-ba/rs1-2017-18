using System;
using Microsoft.AspNetCore.Mvc;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Controllers
{
    [Area(MyAreaNames.ModulAdministracija)]
    public class AjaxController : Controller
    {
        // GET: ModulAdministracija/Ajax
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult Poziv(string ime)
        {
            var s = DateTime.Now.ToString();
            string content = "Zdravo " + ime + "</br>" + s;
            return Content(content, "text/html");
        }
    }
}