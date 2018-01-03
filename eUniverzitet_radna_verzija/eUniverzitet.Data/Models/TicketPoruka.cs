using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eUniverzitet.Data.Models
{
    public class TicketPoruka
    {
        public int Id { get; set; }

        

        public DateTime Vrijeme { get; set; }

        public string Poruka { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }


        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
