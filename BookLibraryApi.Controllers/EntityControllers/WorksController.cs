using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class WorksController : EntityControllerBase<WorksRepository, Work>
    {
        public WorksController(WorksRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
