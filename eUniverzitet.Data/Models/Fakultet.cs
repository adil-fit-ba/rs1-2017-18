namespace eUniverzitet.Data.Models
{
    
    public class Fakultet : OrganizacionaJedinica
    {
        public virtual  NaucnaOblast NaucnaOblast { get; set; }
        public int NaucnaOblastId { get; set; }
    }
}
