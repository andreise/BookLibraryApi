using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class VolumesRepository : RepositoryBase<Volume>
    {
        public VolumesRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
