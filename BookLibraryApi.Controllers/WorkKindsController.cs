using BookLibraryApi.Models;
using BookLibraryApi.Repositories;

namespace BookLibraryApi.Controllers
{
    public sealed class WorkKindsController : ControllerBase<WorkKindsRepository, WorkKind>
    {
        public WorkKindsController(WorkKindsRepository repository) : base(repository)
        {
        }
    }
}
