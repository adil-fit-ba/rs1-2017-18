using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using eUniverzitet.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace eUniverzitet.Web.Helper
{
    public class Autorizacija : ActionFilterAttribute
    {
       
        public KorisnickaUloga[] _uloga { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);

            if (k == null)
            {
                filterContext.HttpContext.Response.Redirect("/Autentifikacija");
                filterContext.HttpContext.Response.StatusCode = 401; //not authorized
                return;
            }

            if (_uloga.Contains(KorisnickaUloga.Student) && k.Student != null)
                return;


            List<Zaposlenje> zaposlenja = Autentifikacija.getZaposlenjes(filterContext.HttpContext);

            if (zaposlenja != null)
            {
                //provjera
                foreach (KorisnickaUloga x in _uloga)
                {
                    if (zaposlenja.Any(z => z.KorisnickaUloga == x))
                        return;
                }
            }

            //ako funkcija nije prekinuta pomoću "return", onda korisnik nema pravo pistupa pa će se vršiti redirekcija na "/Home/Index"
            filterContext.HttpContext.Response.Redirect("/Autentifikacija");

            filterContext.HttpContext.Response.StatusCode = 401; //not authorized

           // base.OnActionExecuting(filterContext);
        }


     
    }
}

