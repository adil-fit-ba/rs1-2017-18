using System.Collections.Generic;
using eUniverzitet.Data.DAL;

namespace eUniverzitet.Data.Models
{
    public enum KorisnickaUloga
    {
        SuperAdministrator,
        AdministratorInstitucije,
        Edukator,
        StudentskaSluzba,
        RadnikOpste,
        Rektor,
        ProrektorZaNastavu,
        ProrektorNIR,
        Dekan,
        ProdekanNastava,
        ProdekanNIR,
        DirektorInstituta,
        BezPrivilegije
    }
    public class Zaposlenik:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual List<Zaposlenje> Zaposlenja { get; set; }
    }
}