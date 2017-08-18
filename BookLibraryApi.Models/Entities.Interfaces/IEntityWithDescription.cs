namespace BookLibraryApi.Models.Entities.Interfaces
{
    public interface IEntityWithDescription : IEntity
    {
        string Description { get; set; }
    }
}
