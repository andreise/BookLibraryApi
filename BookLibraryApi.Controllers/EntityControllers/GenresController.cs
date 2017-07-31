using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class GenresController : EntityControllerBase<GenresRepository, Genre>
    {
        public GenresController(GenresRepository repository) : base(repository)
        {
        }
    }
}
