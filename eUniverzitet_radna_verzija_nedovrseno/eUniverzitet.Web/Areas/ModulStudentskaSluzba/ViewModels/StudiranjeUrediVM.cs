using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models
{
    public class StudiranjeUrediVM
    {
      
        public int Id { get; set; }

        public string BrojIndeksa { get; set; }


        public int? FakultetId { get; set; }
        public List<SelectListItem> FakultetStavke { get; set; }

        public int? OdsjekId { get; set; }
        public List<SelectListItem> OdsjekStavke { get; set; }


        public int? Npp { get; set; }
        public List<SelectListItem> NppStavke { get; set; }
    }
}

