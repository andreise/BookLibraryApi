using BookLibraryApi.Models;
using BookLibraryApi.Repositories;

namespace BookLibraryApi.Controllers
{
    public sealed class GenresController : ControllerBase<GenresRepository, Genre>
    {
        public GenresController(GenresRepository repository) : base(repository)
        {
        }
    }
}
