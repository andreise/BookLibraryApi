using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class WorksController : EntityControllerBase<WorksRepository, Work>
    {
        public WorksController(WorksRepository repository) : base(repository)
        {
        }
    }
}
