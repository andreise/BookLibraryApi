namespace BookLibraryApi.Models
{
    public interface IEntityWithDescription : IEntity
    {
        string Description { get; set; }
    }
}
