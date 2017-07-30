using BookLibraryApi.Models;
using BookLibraryApi.Repositories;

namespace BookLibraryApi.Controllers
{
    public sealed class AuthorsController : ControllerBase<AuthorsRepository, Author>
    {
        public AuthorsController(AuthorsRepository repository) : base(repository)
        {
        }
    }
}
