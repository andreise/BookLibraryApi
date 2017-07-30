using BookLibraryApi.Data.Common;

namespace BookLibraryApi.Models
{
    public interface IEntityWithNameAndDescription : IEntity, IEntityWithName, IEntityWithDescription
    {
    }
}
