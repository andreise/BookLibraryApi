using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class GenresController : EntityControllerBase<GenresRepository, Genre>
    {
        public GenresController(GenresRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
        }
    }
}
