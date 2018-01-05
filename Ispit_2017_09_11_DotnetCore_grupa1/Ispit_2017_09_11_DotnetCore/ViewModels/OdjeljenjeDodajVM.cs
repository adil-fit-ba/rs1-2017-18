using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeDodajVM
    {
        public int razred { get; set; }
        public string oznaka { get; set; }
        public string skGodina { get; set; }

        public List<SelectListItem> RazrednikDropDownStavke;
        public int? RazrednikId { get; set; }
        public List<SelectListItem> NizeOdjeljenjeDropDownListItems;
        public int? NizeOdjeljenjeId { get; set; }
    }
}
