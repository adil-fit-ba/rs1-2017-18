using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Helper;
using Ispit.Data;
using Ispit.Web.ViewModels;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Web.Controllers
{
    [Area("UcenikModul")]
    [Autorizacija(ucenik: true, nastavnici: false)]
    public class UcenikHomeController : Controller
    {
        private MyContext _context;

        public UcenikHomeController(MyContext context)
        {
            _context = context;
        }

        public string Index()
        {
            return "Hello, Ucenik " + HttpContext.GetLogiraniKorisnik().KorisnickoIme;
        }

    }
}