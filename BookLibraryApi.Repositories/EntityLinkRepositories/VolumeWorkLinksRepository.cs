using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.EntityLinks;

namespace BookLibraryApi.Repositories.EntityLinkRepositories
{
    public sealed class VolumeWorkLinksRepository : EntityRepositoryBase<VolumeWorkLink>
    {
        public VolumeWorkLinksRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
