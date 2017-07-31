using BookLibraryApi.Models.EntityLinks;
using BookLibraryApi.Repositories.EntityLinkRepositories;

namespace BookLibraryApi.Controllers.EntityLinkControllers
{
    public sealed class EditionVolumeLinksController : EntityControllerBase<EditionVolumeLinksRepository, EditionVolumeLink>
    {
        public EditionVolumeLinksController(EditionVolumeLinksRepository repository) : base(repository)
        {
        }
    }
}
