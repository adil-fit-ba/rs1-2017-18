namespace Video01.Helper
{
    interface IEntity
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
