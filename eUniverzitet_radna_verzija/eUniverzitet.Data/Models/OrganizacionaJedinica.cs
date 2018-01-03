using System;


namespace eUniverzitet.Data.Models
{
    public enum OrganizacionaJedinicaTip
    {
        Rektorat,
        Fakultet,
        Institut,
        Neodredjeno
    }
    public abstract class OrganizacionaJedinica
    {
        public int Id { get; set; }

        

        public string Naziv { get; set; }

        public Fakultet Fakultet
        {
            get
            {
                if (GetType() == typeof(Fakultet) || GetType().BaseType == typeof(Fakultet))
                    return (Fakultet) this;
                
                return null;
            }
        }

        public Rektorat Rektorat
        {
            get
            {
                if (GetType() == typeof(Rektorat) || GetType().BaseType == typeof(Rektorat))
                    return (Rektorat)this;

                return null;
            }
        }

        public Institut Institut
        {
            get
            {
                if (GetType() == typeof(Institut) || GetType().BaseType == typeof(Institut))
                    return (Institut)this;

                return null;
            }
        }

        public OrganizacionaJedinicaTip OrganizacionaJedinicaTip
        {
            get
            {
                if (Fakultet != null)
                    return OrganizacionaJedinicaTip.Fakultet;
                if (Rektorat != null)
                    return OrganizacionaJedinicaTip.Rektorat;
                if(Institut != null)
                    return OrganizacionaJedinicaTip.Institut;
                return OrganizacionaJedinicaTip.Neodredjeno;
            }
        }
    }
}
