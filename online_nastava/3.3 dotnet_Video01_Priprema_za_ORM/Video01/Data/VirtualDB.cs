using Video01.Helper;
using Video01.Model;

namespace Video01.Data
{
    class VirtualDB
    {
        public static FTable<Student> Studenti { get;  private set; }
        public static FTable<AkademskaGodina> AkademskeGodine { get; private set; }
        public static FTable<Smjer> Smjerovi { get; private set; }
        public static FTable<UpisGodine> UpisiGodine { get; private set; }
        public static FTable<Fakultet> Fakulteti { get; private set; }

        static VirtualDB()
        {
            Studenti = new FTable<Student>();
            AkademskeGodine = new FTable<AkademskaGodina>();
            Smjerovi = new FTable<Smjer>();
            UpisiGodine = new FTable<UpisGodine>();
            Fakulteti = new FTable<Fakultet>();
        }


    }
}
