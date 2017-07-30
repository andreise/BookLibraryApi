namespace HomeLibraryApi.Models
{
    public interface IEntityWithName : IEntity
    {
        string Name { get; set; }
    }
}
