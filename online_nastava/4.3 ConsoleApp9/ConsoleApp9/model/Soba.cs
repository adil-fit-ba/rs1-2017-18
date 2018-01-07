using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9.model
{
    public enum TipSobe
    {
        jednokrevetna, dvokrevetna,
    }
    public class Soba
    {
        public int Id { get; set; }
        public int Naziv { get; set; }
        public int Sprat { get; set; }
        public TipSobe TipSobe { get; set; }
    }
}
