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

    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(params KorisnickaUloga[] item)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { item };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        private IEnumerable<KorisnickaUloga> _uloga;

        public MyAuthorizeImpl(KorisnickaUloga[] uloga)
        {
            _uloga = uloga;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);

            if (k == null)
            {
                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" });
                return;
            }

            if (_uloga.Contains(k.KorisnickaUloga))
                return;


         
            filterContext.Result = new UnauthorizedResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}

