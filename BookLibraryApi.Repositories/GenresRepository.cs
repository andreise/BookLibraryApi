using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class GenresRepository : RepositoryBase<Genre>
    {
        public GenresRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
