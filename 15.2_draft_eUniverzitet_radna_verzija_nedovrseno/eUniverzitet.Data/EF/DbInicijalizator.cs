using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using eUniverzitet.Data.Models;

namespace eUniverzitet.Data.EF
{
    public static class RandomElement {
        static Random random = new Random();
        public static T MyRandom<T>(this List<T> input)
        {
            int s = input.Count;
            return input[random.Next(0, s - 1)];
        }
    }
    public class DbInicijalizator
    {
        static List<Korisnik> korisniks = new List<Korisnik>();
        static List<NaucnaOblast> naucnaOblasts = new List<NaucnaOblast>();
        static List<Zaposlenik> zaposleniks = new List<Zaposlenik>();
        static List<Student> students = new List<Student>();
        static List<Studiranje> studentiranjes = new List<Studiranje>();
        static List<Zaposlenje> zaposlenjes = new List<Zaposlenje>();
        static List<Fakultet> fakulteti = new List<Fakultet>();
        public static void Run(MojContext db)
        {
        //    GenerisiNaucneOblasti();
            GenerisiFakultete(10);
        //    GenerisiOdjseke();
         //   GenerisiNpp();

            GenerisiKorisnike(10);
         //   GenerisiUpisStudenata();
         //   GenerisiUpisStudenata();
        }

        private static void GenerisiFakultete(int x)
        {
            for (int j = 0; j < x; j++)
            {
                Fakultet f = new Fakultet();
                f.Naziv = "Fakultet-" + j;
                f.NaucnaOblast = naucnaOblasts.MyRandom();
                fakulteti.Add(f);
            }
        }

        static Random random = new Random();
        private static void GenerisiKorisnike(int x)
        {
            for (int i = 0; i < x; i++)
            {
                Korisnik k1 = new Korisnik
                {
                    KorisnickoIme = "korsnik" + i,
                    Lozinka = "test",
                    Ime = "Ime" + i,
                    Prezime = "Prezime" + i,
                };
                korisniks.Add(k1);
                Zaposlenik z1 = new Zaposlenik()
                {
                    Korisnik = k1,
                };
                zaposleniks.Add(z1);
                Student s1 = new Student()
                {
                    Korisnik = k1,
                };
                students.Add(s1);

                Studiranje stu1 = new Studiranje
                {
                    Student = s1,
                    BrojIndeksa = new Guid().ToString().Substring(0, 6),
                    UgovorPocetak = DateTime.Now.AddYears(-2),
                    StudentiranjeStatus = StudentiranjeStatus.Aktivan,
                };
                studentiranjes.Add(stu1);

                Studiranje stu2 = new Studiranje
                {
                    Student = s1,
                    BrojIndeksa = new Guid().ToString().Substring(0, 6),
                    UgovorPocetak = DateTime.Now.AddYears(-1),
                    StudentiranjeStatus = StudentiranjeStatus.Aktivan,
                };
                studentiranjes.Add(stu2);
            }
        }
       
        
    }
}
