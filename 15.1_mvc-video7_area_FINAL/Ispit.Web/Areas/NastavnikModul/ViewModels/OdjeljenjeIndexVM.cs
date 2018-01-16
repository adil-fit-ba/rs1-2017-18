using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EntityModels;

namespace Ispit.Web.ViewModels
{
    public class OdjeljenjeIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public double prosjekOcjena;
            public string najboljiUcenik;
            public string SkolskaGodina { get; set; }
            public int Razred { get; set; }
            public string Oznaka { get; set; }
            public string Razrednik { get; set; }
            public bool IsPrebacenuViseOdjeljenje { get; set; }
            public int OdjeljenjeId { get; set; }
        }
    }
}
