using BookLibraryApi.Models.EntityLinks;
using BookLibraryApi.Repositories.EntityLinkRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityLinkControllers
{
    public sealed class VolumeWorkLinksController : EntityControllerBase<VolumeWorkLinksRepository, VolumeWorkLink>
    {
        public VolumeWorkLinksController(VolumeWorkLinksRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
