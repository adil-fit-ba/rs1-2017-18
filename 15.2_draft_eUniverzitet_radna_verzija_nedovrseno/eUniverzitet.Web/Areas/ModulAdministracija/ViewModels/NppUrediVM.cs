using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulAdministracija.Models
{
    public class NppUrediVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public int AkademskaGodinaId { get; set; }
        public List<SelectListItem> AkademskaGodinaStavke { get; set; }
        public int? OdsjekId { get; set; }
        public int FakultetId { get; set; }
    }
}