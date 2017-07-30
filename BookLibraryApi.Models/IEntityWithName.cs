using BookLibraryApi.Data.Common;

namespace BookLibraryApi.Models
{
    public interface IEntityWithName : IEntity
    {
        string Name { get; set; }
    }
}
