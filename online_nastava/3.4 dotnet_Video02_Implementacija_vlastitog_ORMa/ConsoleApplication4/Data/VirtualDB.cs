using Video02.Helper;
using Video02.Model;

namespace Video02.Data
{
    class VirtualDB
    {
        public static FTable<Student> Studenti { set; get; }
        public static FTable<Fakultet> Fakulteti { set; get; }
        public static FTable<Smjer> Smjerovi { set; get; }
        public static FTable<AkademskaGodina> AkademskeGodine { set; get; }
        public static FTable<UpisGodine> UpisiGodine { set; get; }

        private VirtualDB()
        {
          
        }

        static VirtualDB()
        {
            Studenti = new FTable<Student>();
            Fakulteti = new FTable<Fakultet>();
            Smjerovi = new FTable<Smjer>();
            AkademskeGodine = new FTable<AkademskaGodina>();
            UpisiGodine = new FTable<UpisGodine>();
        }
    }
}
