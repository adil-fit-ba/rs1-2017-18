using System;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models.TokStudija
{
    public class UpisaneGodineVM
    {
        public int Id { get; set; }
        public int StudiranjeId { get; set; }


        public DateTime? Datum4_LjetniOvjera;
        public DateTime? Datum3_LjetniUpis;
        public DateTime? Datum2_ZimskiOvjera;
        public DateTime? Datum1_ZimskiUpis;

        public int GodinaStudija { get; set; }
        public float Cijena { get; set; }
        public float Uplaceno { get; set; }
        public int PolozenoPredmeta { get; set; }

    }
}