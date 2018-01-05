using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class StavkeUrediVM
    {
        [Display(Name = "Odjeljenje")]
        public int OdjeljenjeID { get; set; }

        public int OdjeljenjeStavkaID { get; set; }

        public int BrojUDnevniku { get; set; }

        public int UcenikID { get; set; }
        public List<SelectListItem> UceniciSelectListItems { get; set; }

    }
}
