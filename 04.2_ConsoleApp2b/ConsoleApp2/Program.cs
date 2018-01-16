using System;
using ConsoleApp2.EF;
using ConsoleApp2.model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    class Program
    {
        static MojContext db = new MojContext(); //otvara konekciju na db server
        static void Main(string[] args)
        {
            PrimjerDodavanjaNovogObjekta();
            PrimjerPrikazaPodataka();

            PrimjerDodavanjaNovogObjektaSaNovimFK();
            PrimjerDodavanjaNovogObjektaSaOdabiromFK();

            db.Dispose();//ovo zatvara konekciju na DB Server
        }

        private static void PrimjerDodavanjaNovogObjektaSaOdabiromFK()
        {
            Kupac k = new Kupac();


            //varijanta 2
            k.OpstinaId = OdaberiOpstinuFK();

            k.Ime = "Neko Ime";
            db.Kupci.Add(k);

            db.SaveChanges();
        }

        private static int? OdaberiOpstinuFK()
        {
            throw new NotImplementedException();
        }


        private static void PrimjerDodavanjaNovogObjektaSaNovimFK()
        {
            Opstina x = new Opstina();
            x.Naziv = "Neki Naziv";
            db.Opstine.Add(x);

            Kupac k = new Kupac();
            k.Opstina = x;
            k.Ime = "Neko Ime";
            db.Kupci.Add(k);

            db.SaveChanges();
        }

        private static void PrimjerPrikazaPodataka()
        {
            foreach (Kupac x in db.Kupci.Include(x => x.Opstina))
            {
                Console.Write("Ime: " + x.Ime);

                if (x.Opstina != null)
                    Console.Write("Opstina: " + x.Opstina.Naziv);
            }

        }

        private static void PrimjerDodavanjaNovogObjekta()
        {
            //pripremamo objekat koji ce se dodati u tabelu Opstina
            Opstina x = new Opstina();
            x.Naziv = "Neki Naziv";
            db.Opstine.Add(x);

            //izvršavamo SQL
            db.SaveChanges();
        }
    }
}