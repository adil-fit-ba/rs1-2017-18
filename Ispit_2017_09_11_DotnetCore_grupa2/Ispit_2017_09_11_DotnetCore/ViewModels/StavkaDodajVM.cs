using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class StavkaDodajVM
    {
        public int StavkaId;
        public int OdjeljenjeId;
        public int UcenikId;
        public List<SelectListItem> stavkeUcenici;
        public int brUDnevniku; 
    }
}
