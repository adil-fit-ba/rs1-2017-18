using Video02.Helper;

namespace Video02.Model
{
    class Student : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }
        public bool IsDeleted { get; set; }

    }
}
