namespace eUniverzitet.Data.DAL
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }

    }
}
