using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class WorkKindsController : EntityControllerBase<WorkKindsRepository, WorkKind>
    {
        public WorkKindsController(WorkKindsRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
