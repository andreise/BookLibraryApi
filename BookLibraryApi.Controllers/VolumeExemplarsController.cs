using BookLibraryApi.Models;
using BookLibraryApi.Repositories;

namespace BookLibraryApi.Controllers
{
    public sealed class VolumeExemplarsController : ControllerBase<VolumeExemplarsRepository, VolumeExemplar>
    {
        public VolumeExemplarsController(VolumeExemplarsRepository repository) : base(repository)
        {
        }
    }
}
