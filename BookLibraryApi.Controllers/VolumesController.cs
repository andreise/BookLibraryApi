using BookLibraryApi.Models;
using BookLibraryApi.Repositories;

namespace BookLibraryApi.Controllers
{
    public sealed class VolumesController : ControllerBase<VolumesRepository, Volume>
    {
        public VolumesController(VolumesRepository repository) : base(repository)
        {
        }
    }
}
