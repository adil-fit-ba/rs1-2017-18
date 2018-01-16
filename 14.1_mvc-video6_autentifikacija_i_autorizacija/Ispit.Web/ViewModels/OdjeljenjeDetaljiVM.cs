using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EntityModels;

namespace Ispit.Web.ViewModels
{
    public class OdjeljenjeDetaljiVM
    {
        public string Razrednik { get; set; }
        public string Oznaka { get; set; }
        public int Razred { get; set; }
        public string SkolskaGodina { get; set; }
        public int BrojPredmta { get; set; }
        public int OdjeljenjeID { get; set; }
        public int BrojUcenika { get; set; }
    }
}
