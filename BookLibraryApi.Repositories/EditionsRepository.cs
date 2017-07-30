using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class EditionsRepository : RepositoryBase<Edition>
    {
        public EditionsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
