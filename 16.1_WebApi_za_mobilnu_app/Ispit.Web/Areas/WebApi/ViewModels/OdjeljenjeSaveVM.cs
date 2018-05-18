using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.Areas.WebApi.ViewModels
{
    public class OdjeljenjeSaveVM
    {
            public string skolskaGodina { get; set; }
            public string oznaka { get; set; }
            public int razred { get; set; }
            public int? razrednikID { get; set; }
    }
 
}
