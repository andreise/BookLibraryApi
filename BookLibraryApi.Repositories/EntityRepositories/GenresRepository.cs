using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Repositories.EntityRepositories
{
    public sealed class GenresRepository : RepositoryBase<Genre>
    {
        public GenresRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
