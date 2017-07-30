using BookLibraryApi.Models;
using BookLibraryApi.Repositories;

namespace BookLibraryApi.Controllers
{
    public sealed class WorksController : ControllerBase<WorksRepository, Work>
    {
        public WorksController(WorksRepository repository) : base(repository)
        {
        }
    }
}
