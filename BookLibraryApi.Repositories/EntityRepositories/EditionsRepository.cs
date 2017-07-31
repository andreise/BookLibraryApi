using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Repositories.EntityRepositories
{
    public sealed class EditionsRepository : RepositoryBase<Edition>
    {
        public EditionsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
