using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Models
{
    public class PredajeUrediVM
    {
        public int Id { get; set; }

        public List<SelectListItem> NastavniciStavke { get; set; }

        public int AkademskaGodinaId { get; set; }
        public List<SelectListItem> AkademskeGodineStavke { get; set; }
        public int PredmetId { get; set; }
    }
}