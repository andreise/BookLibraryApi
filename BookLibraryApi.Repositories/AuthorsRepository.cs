using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class AuthorsRepository : RepositoryBase<Author>
    {
        public AuthorsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
