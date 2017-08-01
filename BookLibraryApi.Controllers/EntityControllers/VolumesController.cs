using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class VolumesController : EntityControllerBase<VolumesRepository, Volume>
    {
        public VolumesController(VolumesRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
