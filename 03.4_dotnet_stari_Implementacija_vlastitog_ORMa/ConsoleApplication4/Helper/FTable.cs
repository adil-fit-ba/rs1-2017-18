using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using Video02.Data;

namespace Video02.Helper
{
    class FTable<T> where T : class , IEntity
    {
        //C# reflection: Type je klasa koja sadrži metapodatke o drugoj klasi
        public Type type { get; private set; }

        public FTable()
        {
            //T je generički parametar klase FTable
            //C# reflection: type je objekat koja sadrži metapodatke o klasi T
            type = typeof(T);
        }

        public List<T> GetAll()
        {
            List<T> result = new List<T>();

            /*blok "using" automatski poziva funkciju "Dispose" pri njegovom završetku. 
             * Objekat u bloku "using" mora implementirati interface "IDisposable", 
             * koji obavezuje da se implementira funkcija "Dispose"*/
            using (SqlConnection k = Konekcija.getKonekcija())
            {
                //type.Name sadrži naziv klase T
                //"select * from Student"
                string sql = "select * from " + type.Name;
                SqlCommand cmd = new SqlCommand(sql, k);

                //izvršava komandu cmd koja je tipa Query (select)
                SqlDataReader rdr = cmd.ExecuteReader();

                //funkcija Read promjera pokazivač na record/zapis
                //ako Read vrati "false" znači da pokazivač došao na kraj, tj. ne pokazuje više niti na jedan red
                while (rdr.Read())
                {
                    //funkcija NapraviT radi slijedeće
                    //1. pravi instancu klase T, 
                    //2. uzima vrijednosti iz trenutnog zapisa, 
                    //3. setuje vrijednosti trenutnog zapisa u instancu T
                    T newT = NapraviT(rdr);
                    result.Add(newT);
                }
            }

            return result;
        }

        private T NapraviT(SqlDataReader rdr)
        {
            //pravi instancu klase T, 
            T newT = Activator.CreateInstance(typeof(T)) as T;

            //C# reflection: "type.GetProperties()" vraća niz objekata PropertyInfo (Id, IsDeleted, Ime, Prezime, BrojIndeksa).
            //C# reflection: "PropertyInfo" čuva metapodatke o property-u klase, npr. public string BrojIndeksa{get;set;}
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (p.PropertyType == typeof(int) || p.PropertyType == typeof(float) || p.PropertyType == typeof(bool) || p.PropertyType == typeof(string))
                {
                    //"p.Name" je naziv property-a, npr. "BrojIndeksa" (za klasu Student)
                    //"rdr" predstavlja trenuti record na kojeg pokazuje pokazivač na redove
                    //rdr["nesto"] predstavlja pristup koloni "nesto", tj. pristupa se 'čeliji' iz trenutnog reda
                    object v = rdr[p.Name];
                    //postavlja vrijednost v (npr. "IB130033") preko property-a p (npr. BrojIndeksa) u novi objekat newT tipa T (npr. Student)
                    p.SetValue(newT, v);
                }
            }
            return newT;
        }

        public T GetById(int id)
        {
            using (SqlConnection k = Konekcija.getKonekcija())
            {
                //"select * from Student where Id = 4"
                string sql = "select * from " + type.Name + " where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, k);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    T newT = NapraviT(rdr);
                    return newT;
                }
            }

            return null;
        }

        public void Insert(T t)
        {
            string kolone = "";
            foreach (PropertyInfo p in type.GetProperties())
            {
                //U tabeli je uključen Identity (autoinkrement) za kolonu Id, pa je potrebno preskočiti ovu kolonu 
                if (p.Name == "Id")
                    continue;
                if (kolone.Length > 0)
                    kolone += ",";
                kolone += p.Name;
            }

            string vrijednosti = "";
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (p.Name == "Id")
                    continue;
                if (vrijednosti.Length > 0)
                    vrijednosti += ",";
                object v = p.GetValue(t);
                vrijednosti += "'" + v + "'";
            }

            //"Insert into Student(Ime,Prezime,BrojIndeksa,IsDeleted) values ('A','B','IB130434','False')"
            string sql = "insert into " + type.Name + "(" + kolone + ") values (" + vrijednosti + ")";

            using (SqlConnection k = Konekcija.getKonekcija())
            {
                SqlCommand cmd = new SqlCommand(sql, k);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(T t)
        {
            using (SqlConnection k = Konekcija.getKonekcija())
            {
                //"delete from Student where Id = 4"
                string sql = "delete from " + type.Name + " where Id = " + t.Id;
                SqlCommand cmd = new SqlCommand(sql, k);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(T t)
        {
            //TODO: Pokušajte implementirati. Ovo je slično funkciji Insert.
        }
    }
}
