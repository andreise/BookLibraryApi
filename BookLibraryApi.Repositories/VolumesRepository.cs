using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class VolumesRepository : Repository<Volume>
    {
        public VolumesRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
