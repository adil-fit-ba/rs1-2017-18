using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp9.atributi;
using ConsoleApp9.EF;
using ConsoleApp9.model;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            string u;
            do
            {
                Console.WriteLine("1. dodaj opstinu");
                Console.WriteLine("2. dodaj klijenta");
                Console.WriteLine("0. exit");
                u = Console.ReadLine();
                if (u == "1")
                    m1_opstina_dodaj();
                if (u == "2")
                    m2_klijent_dodaj();
            } while (u!="0");

          
        }

        private static void m2_klijent_dodaj()
        {
            Klijent o = new Klijent();
            Console.WriteLine("Unesite ime i prezime klijenta: ");
            o.ImePrezime = Console.ReadLine();

            Console.WriteLine("Odaberite opstinu: ");
            o.OpstinaId = odabirOpstine();

            if (o.OpstinaId == null)
            {
                Console.WriteLine("Unesite novu opstinu: ");
                o.Opstina = new Opstina();
                o.Opstina.Naziv = Console.ReadLine();
            }
            using (MojContext context = new MojContext())
            {
                context.Klijent.Add(o);
                context.SaveChanges();
            }
        }

        private static int? odabirOpstine()
        {

            using (MojContext context = new MojContext())
            {
                int b = 1;
                List<Opstina> opstine = context.Opstina.ToList(); //select * from Opstina
                foreach (Opstina x in opstine)
                {
                    Console.WriteLine(b++ + ". " + x.Naziv);
                }
                int i = int.Parse(Console.ReadLine());
                //RB
                if (i == 0)
                    return null;
                Opstina o = opstine[i-1];
                return o.Id;
            }
        }

        private static void m1_opstina_dodaj()
        {
            Opstina o = new Opstina();
            Console.WriteLine("Unesite naziv opstine: ");
            o.Naziv = Console.ReadLine();

            using (MojContext context = new MojContext())
            {
                context.Opstina.Add(o);
                context.SaveChanges();
            }
        }
    }
}