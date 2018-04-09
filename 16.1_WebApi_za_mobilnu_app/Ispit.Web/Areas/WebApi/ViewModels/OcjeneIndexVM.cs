using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.Areas.WebApi.ViewModels
{
    public class AdminOdjeljenjaVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int OdeljenjeId { get; set; }
            public string SkolskaGodina { get; set; }
            public string Razrednik { get; set; }
            public string Oznaka { get; set; }
            public int Razred { get; set; }
        }
    }
 
}
