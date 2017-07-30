namespace HomeLibraryApi.Models
{
    public interface IEntityWithDescription : IEntity
    {
        string Description { get; set; }
    }
}
