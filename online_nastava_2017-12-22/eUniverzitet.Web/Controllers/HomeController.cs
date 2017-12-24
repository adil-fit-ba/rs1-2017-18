using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Data;
using Microsoft.AspNetCore.Mvc;
using eUniverzitet.Web.Models;

namespace eUniverzitet.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

    }
}
