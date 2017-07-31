using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Repositories.EntityRepositories
{
    public sealed class AuthorsRepository : RepositoryBase<Author>
    {
        public AuthorsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
