using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.model
{
    public class Kupac
    {
        public int Id { get; set; }
        public string Ime { get; set; }

        public virtual Opstina Opstina { get; set; }
        public int? OpstinaId { get; set; }
    }
}
