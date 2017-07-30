using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class WorkKindsRepository : Repository<WorkKind>
    {
        public WorkKindsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
