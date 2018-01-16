using System.Collections.Generic;

namespace Video01.Helper
{
    class FTable<T> where T:class, IEntity
    {
        /*
         U klasu FTable dodajte  
            a)	privatni property List<T> podaci
            b)	funkciju GetAll
            c)	funkciju GetById
            d)	funkciju Insert
            e)	funkciju Update
            f)	funkciju Delete
         */

        public FTable()
        {
            Podaci = new List<T>();
        }

        //a
        private List<T> Podaci { get; set; }

        //b
        public List<T> GetAll()
        {
            return Podaci;
        }

        //b
        public T GetById(int id)
        {
            foreach (T t in Podaci)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }
            return null;
        }

        private int identity = 0;
        public void Insert(T newT)
        {
            newT.Id = ++identity;
            Podaci.Add(newT);
        }

        public void Update(T t)
        {
            Delete(t.Id);
            Insert(t);
        }

        public void Delete(int id)
        {
            T t = GetById(id);
            Podaci.Remove(t);
        }
        
    }
}
