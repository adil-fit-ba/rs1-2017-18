using System;
using System.Collections.Generic;
using Video01.Data;
using Video01.Model;

namespace Video01.UI
{
    class Student_UI
    {
        public static void PrikaziStudente()
        {
            List<Student> students = VirtualDB.Studenti.GetAll();
            foreach (Student s in students)
            {
                Console.WriteLine("Id = " + s.Id);
                Console.WriteLine("Ime = " + s.Ime);
                Console.WriteLine("Prezime = " + s.Prezime);
                Console.WriteLine("Broj indeksa = " + s.BrojIndeksa);
                Console.WriteLine("=================");
            }
        }

        public static void DodajStudenta()
        {
            Student s = new Student();
            Console.WriteLine("Unesite ime");
            s.Ime = Console.ReadLine();

            Console.WriteLine("Unesite prezime");
            s.Prezime = Console.ReadLine();

            Console.WriteLine("Unesite broj indeksa");
            s.BrojIndeksa = Console.ReadLine();

            VirtualDB.Studenti.Insert(s);

            Console.WriteLine("=================");
        }

    }
}





