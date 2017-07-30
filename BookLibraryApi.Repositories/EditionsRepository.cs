using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class EditionsRepository : Repository<Edition>
    {
        public EditionsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
