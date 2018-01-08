using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ispit_2017_09_11_DotnetCore.EntityModels
{
    public class Odjeljenje
    {
        public int Id { get; set; }
        public string SkolskaGodina { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public bool IsPrebacenuViseOdjeljenje { get; set; }
        public int? RazrednikID { get; set; }
        [ForeignKey(nameof(RazrednikID))]
        public Nastavnik Razrednik { get; set; }
    }
}
