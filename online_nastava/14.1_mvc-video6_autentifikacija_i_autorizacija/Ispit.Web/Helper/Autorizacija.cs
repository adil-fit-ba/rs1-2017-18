using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Data.Models;
using eUniverzitet.Web.Controllers;
using Ispit.Data;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;


namespace eUniverzitet.Web.Helper
{

    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool ucenik, bool nastavnici)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { ucenik, nastavnici };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool ucenik, bool nastavnici)
        {
            _ucenik = ucenik;
            _nastavnici = nastavnici;
        }
        private readonly bool _ucenik;
        private readonly bool _nastavnici;
        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            KorisnickiNalog k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste logirani";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" });
                return;
            }

            //Preuzimamo DbContext preko app services
            MyContext db = filterContext.HttpContext.RequestServices.GetService<MyContext>();

            //ucenici mogu pristupiti studenti
            if (_ucenik && db.Ucenik.Any(s => s.KorisnickiNalogId == k.Id))
            {
                await next(); //ok - ima pravo pristupa
                return;
            }

            //nastavnici mogu pristupiti studenti
            if (_nastavnici && db.Nastavnik.Any(s => s.KorisnickiNalogId == k.Id))
            {
                await next();//ok - ima pravo pristupa
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.ViewData["error_poruka"] = "Nemate pravo pristupa";
            }
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { @area = "" });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}

