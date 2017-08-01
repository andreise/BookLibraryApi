using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class AuthorsController : EntityControllerBase<AuthorsRepository, Author>
    {
        public AuthorsController(AuthorsRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
