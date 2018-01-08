using Video02.Helper;

namespace Video02.Model
{
    class Fakultet:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Naziv { get; set; }
    }
}
