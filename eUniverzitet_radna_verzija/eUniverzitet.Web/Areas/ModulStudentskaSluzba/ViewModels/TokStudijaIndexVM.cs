using System.Collections.Generic;
using eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models.TokStudija;

namespace eUniverzitet.Web.Areas.ModulStudentskaSluzba.Models
{
    public class TokStudijaIndexVM
    {
        public OpsteInfoVM OpsteInfo { get; set; }
        public List<UpisaneGodineVM> UpisaneGodine { get; set; }
        public List<SlusaPredmeteVM> SlusaPredmete { get; set; }
        public List<UplataVM> Uplate { get; set; }
        public UpisGodineDetaljnoVM UpisGodineDetaljno { get; set; }
    }
}