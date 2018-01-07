using ConsoleApp2.EF;
using ConsoleApp2.model;
using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            MojContext db = new MojContext(); //otvara konekciju na db server

            //pripremamo objekat koji ce se dodati u tabelu Opstina
            Opstina x = new Opstina();
            Console.WriteLine("Unesite naziv za novu opstine: ");
            x.Naziv = Console.ReadLine();
            db.Opstine.Add(x);

            //izvršavamo SQL
            db.SaveChanges();


            foreach (Opstina o in db.Opstine)
            {
                Console.WriteLine("Naziv: " + o.Naziv);
            }

            db.Dispose();//ovo zatvara konekciju na DB Server

            
        }
    }
}