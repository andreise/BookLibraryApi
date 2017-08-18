namespace BookLibraryApi.Models.Entities.Interfaces
{
    public interface IEntityWithName : IEntity
    {
        string Name { get; set; }
    }
}
