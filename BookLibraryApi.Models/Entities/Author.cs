using BookLibraryApi.Models.Entities.Interfaces;

namespace BookLibraryApi.Models.Entities
{
    public sealed class Author : IEntityWithNameAndDescription
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
