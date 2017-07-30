using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class VolumeExemplarsRepository : RepositoryBase<VolumeExemplar>
    {
        public VolumeExemplarsRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
