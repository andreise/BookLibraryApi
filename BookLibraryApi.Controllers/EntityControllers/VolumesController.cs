using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class VolumesController : EntityControllerBase<VolumesRepository, Volume>
    {
        public VolumesController(VolumesRepository repository) : base(repository)
        {
        }
    }
}
