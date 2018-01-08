using System;
using Video01.UI;

namespace Video01
{
    class Program
    {
        static void Main(string[] args)
        {
            int unos;
            do
            {
                Console.WriteLine("1. Dodaj studenta");
                Console.WriteLine("2. Prikazi studenta");
                Console.WriteLine("3. EXIT");
                unos = int.Parse(Console.ReadLine());
                if (unos == 1)
                    Student_UI.DodajStudenta();
                if (unos == 2)
                    Student_UI.PrikaziStudente();
            } while (unos != 3);
        }
    }
}
