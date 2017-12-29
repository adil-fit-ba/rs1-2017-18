using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class StavkeController : Controller
    {
        private MojContext _context;
        public StavkeController(MojContext context)
        {
            this._context = context;
        }
        public IActionResult Index(int odjeljenjeID)
        {
            return View();
        }
    }
}