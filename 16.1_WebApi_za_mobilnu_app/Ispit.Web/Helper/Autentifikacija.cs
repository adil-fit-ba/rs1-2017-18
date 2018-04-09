using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUniverzitet.Data.Models;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Ispit.Web.Helper;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace eUniverzitet.Web.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, KorisnickiNalog korisnik, bool snimiUCookie=false)
        {

            MyContext db = context.RequestServices.GetService<MyContext>();

            string stariToken1 = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (stariToken1 != null)
            {
                AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken1);
                if (obrisati != null)
                {
                    db.AutorizacijskiToken.Remove(obrisati);
                    db.SaveChanges();
                }
            }

            string stariToken2 = context.Session.Get<string>(LogiraniKorisnik);
            if (stariToken2 != null)
            {
                AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken2);
                if (obrisati != null)
                {
                    db.AutorizacijskiToken.Remove(obrisati);
                    db.SaveChanges();
                }
            }

            if (korisnik != null)
            {

                string token = Guid.NewGuid().ToString();
                db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    KorisnickiNalogId = korisnik.Id,
                    VrijemeEvidentiranja = DateTime.Now
                });
                db.SaveChanges();
                context.Session.Set(LogiraniKorisnik, token);
                if (snimiUCookie)
                    context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
        }

        public static string GetTrenutniToken(this HttpContext context)
        {
            string token = context.Session.Get<string>(LogiraniKorisnik);
            if (token == null)
                token =  context.Request.GetCookieJson<string>(LogiraniKorisnik);

            return token;
        }

        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext context)
        {
            MyContext db = context.RequestServices.GetService<MyContext>();

            string token = GetTrenutniToken(context);
            if (token == null)
                return null;

            return db.AutorizacijskiToken
                .Where(x => x.Vrijednost == token)
                .Select(s => s.KorisnickiNalog)
                .SingleOrDefault();

        }

    }
}