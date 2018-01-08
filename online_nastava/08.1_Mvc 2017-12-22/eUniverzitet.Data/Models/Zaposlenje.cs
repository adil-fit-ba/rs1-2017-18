using System;
using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{

    public class Zaposlenje:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public int ZaposlenikId { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }


        public DateTime UgovorPocetak { get; set; }
        public DateTime? UgovorKraj { get; set; }

        public int OrganizacionaJedinicaId { get; set; }
        public virtual OrganizacionaJedinica OrganizacionaJedinica { get; set; }

        public int ZaposlenjeMjestoId { get; set; }
        public virtual ZaposlenjeMjesto ZaposlenjeMjesto { get; set; }

        public virtual KorisnickaUloga KorisnickaUloga { get; set; }
    }
}