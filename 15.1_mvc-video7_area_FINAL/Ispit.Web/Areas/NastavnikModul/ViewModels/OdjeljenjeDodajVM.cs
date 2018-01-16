using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ispit.Web.Controllers;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit.Web.ViewModels
{
    public class OdjeljenjeDodajVM
    {
        public string nastavnik;

        [Required]
        [StringLength(3)]
        [RegularExpression("[1-9][-][a-z]")]
        [Remote(action: nameof(OdjeljenjeController.ProvjeriOznaku), controller: "Odjeljenje", AdditionalFields = nameof(skolaGodina))]
        public string oznaka { get; set; }
        public int odjeljenjeID { get; set; }
        public List<SelectListItem> odjeljenja { get; set; }
        [Required]
        [StringLength(7)]
        [RegularExpression(@"[0-9]{4}[\/-][0-9]{2}")]
        [Remote(action: nameof(OdjeljenjeController.ProvjeriOznaku), controller: "Odjeljenje", AdditionalFields = nameof(oznaka))]

        public string skolaGodina { get; set; }
        [Range(1,9)]
        public int razred { get; set; }
    }
}
