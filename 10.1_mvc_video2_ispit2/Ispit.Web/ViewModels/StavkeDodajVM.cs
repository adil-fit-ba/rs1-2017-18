using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit.Web.ViewModels
{
    public class StavkeDodajVM
    {
        public IEnumerable<SelectListItem> ucenici;
        public int OdjeljenjeID { get; set; }
        public int UcenikID { get; set; }
        public int BrojUdnevniku { get; set; }
        public int OdjeljenjeStavkaId { get; set; }
    }
}
