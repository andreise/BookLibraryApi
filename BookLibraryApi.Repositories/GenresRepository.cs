using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class GenresRepository : Repository<Genre>
    {
        public GenresRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
