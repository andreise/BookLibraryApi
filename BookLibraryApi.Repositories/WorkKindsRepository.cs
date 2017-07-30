using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class WorkKindsRepository : RepositoryBase<WorkKind>
    {
        public WorkKindsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
