using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class VolumeExemplarsRepository : Repository<VolumeExemplar>
    {
        public VolumeExemplarsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
