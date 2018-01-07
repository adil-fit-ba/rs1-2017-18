using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9.atributi
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PomocniAtribut : Attribute
    {
        public string Tekst { get; set; }

    }
}
