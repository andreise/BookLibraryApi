using BookLibraryApi.Models.EntityLinks;
using BookLibraryApi.Repositories.EntityLinkRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityLinkControllers
{
    public sealed class WorkAuthorLinksController : EntityControllerBase<WorkAuthorLinksRepository, WorkAuthorLink>
    {
        public WorkAuthorLinksController(WorkAuthorLinksRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
