using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Newtonsoft.Json.Serialization;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeDetaljiVM
    {

        public int OdjeljenjeID { get; set; }
        public string SkolskaGodina { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public string Razrednik { get; set; }
        public int BrojPredmeta { get; set; }

    }
}
