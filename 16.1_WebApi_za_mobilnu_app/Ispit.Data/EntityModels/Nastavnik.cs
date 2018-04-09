using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Data.Models;

namespace Ispit_2017_09_11_DotnetCore.EntityModels
{
    public class Nastavnik
    {
        [Key]
        public int NastavnikID { get; set; }
        public string ImePrezime { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int? KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
