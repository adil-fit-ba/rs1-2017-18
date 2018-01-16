using System;
using System.Collections.Generic;
using eUniverzitet.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models
{

    public class StudentIndexVM
    {
        public class StudentiranjeInfo
        {
            public int Id { get; set; }
            public string Fakultet { get; set; }
            public string Odjsek { get; set; }
            public StudentiranjeStatus Status { get; set; }
            public DateTime Pocetak { get; set; }
            public DateTime? Kraj { get; set; }

        }
         public class StudentInfo
         {
             public int Id { get; set; }
             public string Ime { get; set; }
             public string Prezime { get; set; }
             public DateTime DatumRodjenja { get; set; }

             public List<StudentiranjeInfo> StudentiranjeInfos { get; set; }
         }

         public List<StudentInfo> TabelaPodaci;

         public int? FakultetId { get; set; }
        public IEnumerable<SelectListItem> FakultetStavke { get; set; }
    }
}