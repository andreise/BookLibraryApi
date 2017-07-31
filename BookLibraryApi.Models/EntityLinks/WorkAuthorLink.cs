using BookLibraryApi.Data.Common;

namespace BookLibraryApi.Models.EntityLinks
{
    public sealed class WorkAuthorLink : IEntity
    {
        public int? Id { get; set; }

        public int? WorkId { get; set; }

        public int? AuthorId { get; set; }
    }
}
