using BookLibraryApi.Models.EntityLinks;
using BookLibraryApi.Repositories.EntityLinkRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityLinkControllers
{
    public sealed class EditionVolumeLinksController : EntityControllerBase<EditionVolumeLinksRepository, EditionVolumeLink>
    {
        public EditionVolumeLinksController(EditionVolumeLinksRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
