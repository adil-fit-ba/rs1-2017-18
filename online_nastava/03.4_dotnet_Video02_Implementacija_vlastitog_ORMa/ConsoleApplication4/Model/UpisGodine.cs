using System;
using Video02.Helper;

namespace Video02.Model
{
    class UpisGodine:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DatumUpisa { get; set; }
        public int GodinaStudija { get; set; }
        public int StudentId { get; set; }
        public int SmjerId { get; set; }
        public int AkademskaGodinaId { get; set; }
    }
}
