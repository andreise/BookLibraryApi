using BookLibraryApi.Models.EntityLinks;
using BookLibraryApi.Repositories.EntityLinkRepositories;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class VolumeWorkLinksController : EntityControllerBase<VolumeWorkLinksRepository, VolumeWorkLink>
    {
        public VolumeWorkLinksController(VolumeWorkLinksRepository repository) : base(repository)
        {
        }
    }
}
