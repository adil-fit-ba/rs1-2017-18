using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models
{
    public class UpisGodineDetaljnoVM
    {
        public DateTime? Datum1_ZimskiUpis { get; set; }
        public DateTime? Datum2_ZimskiOvjera { get; set; }
        public DateTime? Datum3_LjetniUpis { get; set; }
        public DateTime? Datum4_LjetniOvjera { get; set; }
        public int Id { get; set; }
        public int GodinaStudija { get; set; }

        public IEnumerable<SelectListItem> GodinaStudijaOptions
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem() {Text = "1"},
                    new SelectListItem() {Text = "2"},
                    new SelectListItem() {Text = "3"}
                };
            }
        }

        public int AkademskaGodinaId { get; set; }
        public IEnumerable<SelectListItem> AkademskaGodinaOptions { get; set;}
        public float Cijena { get; set; }
    }
}