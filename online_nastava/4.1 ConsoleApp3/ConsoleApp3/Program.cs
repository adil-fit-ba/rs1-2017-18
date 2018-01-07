using ConsoleApp3.model;
using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            MojContext myCtx = new MojContext();

            Soba novaSoba = new Soba();
            novaSoba.brojKreveta = 2;
            myCtx.Soba.Add(novaSoba);

            Klijent klijent = new Klijent();
            klijent.ImePrezime = "John Smith";
            myCtx.Klijent.Add(klijent);

            myCtx.SaveChanges();

        }
    }
}