using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class WorksRepository : Repository<Work>
    {
        public WorksRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
