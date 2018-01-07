using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Student
    {
        internal string password;
        internal string zanimanje;
        internal bool isDL;

        public int id{ get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }

    }
}
