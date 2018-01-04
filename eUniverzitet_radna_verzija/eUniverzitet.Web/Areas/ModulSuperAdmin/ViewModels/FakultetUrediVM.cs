using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class FakultetUrediVM
    {
        public string Opis { get; set; }
        public int Id { get; set; }

        public int NaucnaOblastId { get; set; }

        public List<SelectListItem> NaucnaOblastStavke { get; set; }
    }
}