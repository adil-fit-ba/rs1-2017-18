using System.ComponentModel.DataAnnotations.Schema;
using eUniverzitet.Data.Models;

namespace Ispit_2017_09_11_DotnetCore.EntityModels
{
    public class Ucenik
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int? KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
