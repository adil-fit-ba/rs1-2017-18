using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Web.Controllers
{
    public class HtmlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Camera1()
        {
            return View();
        }

        public IActionResult Gps1()
        {
            return View();
        }

        public IActionResult Gps2()
        {
            return View();
        }

        public IActionResult Camera2()
        {
            return View();
        }
    }
}