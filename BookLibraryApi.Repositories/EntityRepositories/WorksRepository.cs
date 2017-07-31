using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Repositories.EntityRepositories
{
    public sealed class WorksRepository : RepositoryBase<Work>
    {
        public WorksRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
