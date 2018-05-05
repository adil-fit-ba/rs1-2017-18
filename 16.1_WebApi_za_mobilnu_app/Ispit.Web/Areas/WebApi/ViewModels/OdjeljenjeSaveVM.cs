using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.Areas.WebApi.ViewModels
{
    public class OdjeljenjeSaveVM
    {
            public string SkolskaGodina { get; set; }
            public string Oznaka { get; set; }
            public int Razred { get; set; }
            public int? RazrednikID { get; set; }
    }
 
}
