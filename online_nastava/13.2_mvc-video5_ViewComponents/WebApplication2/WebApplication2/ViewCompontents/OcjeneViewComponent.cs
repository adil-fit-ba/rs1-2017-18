using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.ViewCompontents
{
    public class Ocjene: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int studentId)
        {
            MojKontext kontext = new MojKontext();
            OcjeneVM ocjene = new OcjeneVM();
            ocjene.Rows = kontext.ocjene
                .Where(x=>x.studentId == studentId)
                .Select(x => new OcjeneVM.Row
            {
                datum = x.Datum,
                napomena = x.Napomena,
                ocjena = x.BrojcanaOcjena
            }).ToList();

            return View("AA", ocjene);

        }
    }
}
