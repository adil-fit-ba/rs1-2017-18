using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class ProbaController:Controller
    {
        public IActionResult Test1()
        {
            return View();
        }
        public string Index()
        {
            return "Index akcija izmjena";
        }
    }
}
