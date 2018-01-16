using System;
using System.Collections.Generic;
using System.Text;

namespace eUniverzitet.Data.Models
{
    public enum KorisnickaUloga
    {
        SuperAdministrator = 10,
        AdministratorInstitucije = 11,
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
        BezPrivilegije,
        Student
    }
}
