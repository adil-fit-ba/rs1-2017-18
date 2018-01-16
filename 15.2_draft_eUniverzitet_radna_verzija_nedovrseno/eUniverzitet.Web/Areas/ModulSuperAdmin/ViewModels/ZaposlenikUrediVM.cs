using System.ComponentModel.DataAnnotations;

namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class ZaposlenikUrediVM
    {
        public int korisnikId;
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string KorisnickoIme { get; set; }

        [Required]
        public string Lozinka { get; set; }
    }
}