using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class VolumeExemplarsController : EntityControllerBase<VolumeExemplarsRepository, VolumeExemplar>
    {
        public VolumeExemplarsController(VolumeExemplarsRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
