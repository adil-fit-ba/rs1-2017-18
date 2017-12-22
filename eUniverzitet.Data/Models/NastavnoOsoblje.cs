namespace eUniverzitet.Data.Models
{
    public enum NastavnoOsobljeZvanje
    {
        Asistent,
        VisiAsistent,
        Docent,
        VanredniProfesor,
        RedovniProfesor
    }

    public class NastavnoOsoblje : Zaposlenje
    {
        public NastavnoOsobljeZvanje NastavnoOsobljeZvanje { get; set; }

    }
}
