using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Repositories.EntityRepositories
{
    public sealed class VolumesRepository : EntityRepositoryBase<Volume>
    {
        public VolumesRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
