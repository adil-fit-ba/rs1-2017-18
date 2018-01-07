using Video01.Helper;

namespace Video01.Model
{
    class Student:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }

       
    }
}
