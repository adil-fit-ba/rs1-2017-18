using System;
using System.ComponentModel.DataAnnotations;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models
{
    public class StudentUrediVM
    {
      
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        public string Prezime { get; set; }

        public string KorisnickoIme { get; set; }
         [Required(ErrorMessage = "Lozinka je obavezno polje")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Lozinka mora imati najmanje 5 a najviše 30 karaktera")]
        public string Lozinka { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        public int KorisnikId { get; set; }
    }
}

