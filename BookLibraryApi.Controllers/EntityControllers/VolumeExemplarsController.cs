using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class VolumeExemplarsController : EntityControllerBase<VolumeExemplarsRepository, VolumeExemplar>
    {
        public VolumeExemplarsController(VolumeExemplarsRepository repository) : base(repository)
        {
        }
    }
}
