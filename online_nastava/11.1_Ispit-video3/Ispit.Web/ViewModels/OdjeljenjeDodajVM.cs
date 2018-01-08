using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit.Web.ViewModels
{
    public class OdjeljenjeDodajVM
    {
        public string oznaka { get; set; }
        public int razrednikID { get; set; }
        public int odjeljenjeID { get; set; }
        public List<SelectListItem> nastavnici { get; set; }
        public List<SelectListItem> odjeljenja { get; set; }
        public string skolaGodina { get; set; }
        public int razred { get; set; }
    }
}
