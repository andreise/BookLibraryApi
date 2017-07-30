using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class WorksRepository : RepositoryBase<Work>
    {
        public WorksRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
