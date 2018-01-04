namespace eUniverzitet.Web.Areas.ModulSuperAdmin.Models
{
    public class OdsjekUrediVM
    {
        public int Id { get; set; }
        public string OdjsekNaziv { get; set; }
        public int FakultetId { get; set; }
        public string FakultetNaziv { get; set; }
    }
}