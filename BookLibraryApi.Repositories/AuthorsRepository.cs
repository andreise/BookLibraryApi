using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class AuthorsRepository : Repository<Author>
    {
        public AuthorsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
