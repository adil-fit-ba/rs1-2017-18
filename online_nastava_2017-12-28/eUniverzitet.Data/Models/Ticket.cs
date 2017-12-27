using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class Ticket:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Naslov { get; set; }

        public int? TicketKategorijaId { get; set; }
        public virtual TicketKategorija TicketKategorija { get; set; }

        public int? IzvodjenjePredmetaId { get; set; }
        public virtual IzvodjenjePredmeta IzvodjenjePredmeta { get; set; }

        public virtual List<TicketPoruka> TicketPorukas { get; set; }

        public int StudiranjeId { get; set; }
        public virtual Studiranje Studiranje { get; set; }

        public int? ZaposlenikId { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }

        public bool IsZatvoren { get; set; }

    }
}
