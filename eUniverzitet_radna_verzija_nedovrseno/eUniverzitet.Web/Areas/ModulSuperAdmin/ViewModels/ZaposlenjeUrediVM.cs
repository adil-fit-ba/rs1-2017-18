using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using eUniverzitet.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class ZaposlenjeUrediVM
    {
        public int zaposlenikId { get; set; }
        public int Id { get; set; }


        [Required]
        public DateTime? DatumPocetak { get; set; }

        [Required]
        public int? OrganizacionaJedinicaId { get; set; }

        public List<SelectListItem> OrganizacionaJedinicaStavke { get; set; }

        [Required]
        public int? ZaposljenjeMjestoId { get; set; }

        public List<SelectListItem> ZaposlenjeMjestoStavke { get; set; }

        [Required]
        public KorisnickaUloga? KorisnickaUloga { get; set; }

        public List<SelectListItem> KorisnickaUlogaStavke { get; set; }
        public DateTime? DatumKraj { get; set; }
    }
}