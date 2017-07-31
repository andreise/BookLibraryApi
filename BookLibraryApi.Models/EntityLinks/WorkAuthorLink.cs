using BookLibraryApi.Data.Common;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Models.EntityLinks
{
    public sealed class WorkAuthorLink : IEntity
    {
        public int? Id { get; set; }

        public int? WorkId { get; set; }

        public Work Work { get; set; }

        public int? AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
