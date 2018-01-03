using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUniverzitet.Data.EF;
using eUniverzitet.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eUniverzitet.Web.Helper
{
    public class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void PokreniNovuSesiju(Korisnik korisnik, HttpContext context, bool zapamtiPassword)
        {
            context.Session.SetJson(LogiraniKorisnik, korisnik);

         
        }

        public static Korisnik GetLogiraniKorisnik(HttpContext context)
        {
            Korisnik korisnik = context.Session.GetJson<Korisnik>(LogiraniKorisnik);

            return korisnik;
        }


        public static List<Zaposlenje> getZaposlenjes(HttpContext context)
        {
            Korisnik k = GetLogiraniKorisnik(context);
            if (k == null || k.Zaposlenik == null)
                return null;

            MojContext ctx = context.RequestServices.GetService<MojContext>();

            //ServiceCollection a = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            //using (var x = a.GetService<MojContext>().CreateContext())
            //{
                
            //}
                

            int id = k.Zaposlenik.Id;
            return ctx.Zaposlenjes.Where(x => x.ZaposlenikId == id).ToList();
        }



        public static List<Studiranje> getStudiranjes(HttpContext context)
        {
            Korisnik k = GetLogiraniKorisnik(context);
            if (k == null || k.Student == null)
                return null;

            MojContext ctx = context.RequestServices.GetService<MojContext>(); ;
            return ctx.Studiranjes.Where(x => x.StudentId == k.Student.Id).ToList();
        }


    }
}