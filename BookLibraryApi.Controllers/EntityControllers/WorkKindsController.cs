using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class WorkKindsController : EntityControllerBase<WorkKindsRepository, WorkKind>
    {
        public WorkKindsController(WorkKindsRepository repository) : base(repository)
        {
        }
    }
}
