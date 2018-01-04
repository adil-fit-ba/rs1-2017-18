using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models
{

    public class StudiranjeIndexVM
    {
         public class StudiranjeInfo
         {
             public string Fakultet_Naziv;

             public string Odsjek_Naziv;
             public float EctsUkupno { get; set; }
             public int BrojPolozenihPredmeta { get; set; }
             public int Id { get; set; }
             public string Ime { get; set; }
             public string Prezime { get; set; }
             public string BrojIndeksa { get; set; }
             public DateTime DatumRodjenja { get; set; }
         }

         public List<StudiranjeInfo> TabelaPodaci;

         public List<SelectListItem>  OdsjekStavke { get; set; }
         public List<SelectListItem> FakultetStavke { get; set; }
        public int SmjeriId { get; set; }
    }
}