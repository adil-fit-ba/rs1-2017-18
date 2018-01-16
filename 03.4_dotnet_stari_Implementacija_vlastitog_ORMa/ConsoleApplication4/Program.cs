using System;
using Video02.UI;

namespace Video02
{
    class Program
    {
        static void Main(string[] args)
        {
            int unos = 0;
            do
            {
                Console.WriteLine("1. Dodaj studenta");
                Console.WriteLine("2. Prikazi studenta");
                Console.WriteLine("3. EXIT");
                try
                {
                    unos = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("pogrešan unos");
                }
                if (unos == 1)
                    Student_UI.DodajStudenta();  
                if (unos == 2)
                    Student_UI.PrikaziStudente();
            } while (unos != 3);
        }
    }
}
