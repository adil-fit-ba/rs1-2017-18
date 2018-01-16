using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Db;
using WebApplication5.EntityModels;

namespace WebApplication5.Controllers
{
    public class StudentiController : Controller
    {
        public IActionResult Index()
        {
            List<Student> podaci1 = VirtualDB.student;
            ViewData["kljuc1"] = podaci1;
            return View();
        }

        public IActionResult Obrisi(int id)
        {
            Student p1 = VirtualDB.student.Where(x => x.Id == id).FirstOrDefault();
            VirtualDB.student.Remove(p1);
            return RedirectToAction("Index");
        }
    }
}