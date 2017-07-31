using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Repositories.EntityRepositories
{
    public sealed class WorksRepository : EntityRepositoryBase<Work>
    {
        public WorksRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
