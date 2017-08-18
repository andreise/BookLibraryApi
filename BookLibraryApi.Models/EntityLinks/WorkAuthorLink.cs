using BookLibraryApi.Models.Entities;
using BookLibraryApi.Models.Entities.Interfaces;

namespace BookLibraryApi.Models.EntityLinks
{
    public sealed class WorkAuthorLink : IEntity
    {
        public int Id { get; set; }

        public int WorkId { get; set; }

        public Work Work { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
