using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public class TicketKategorija : IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Opis { get; set; }
       
    }
}
