using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Repositories.EntityRepositories
{
    public sealed class WorkKindsRepository : RepositoryBase<WorkKind>
    {
        public WorkKindsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
