using Video02.Helper;

namespace Video02.Model
{
    class Smjer:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Opis { get; set; }

        public int FakultetId { get; set; }
    }
}
