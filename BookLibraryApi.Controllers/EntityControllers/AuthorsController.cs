using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class AuthorsController : EntityControllerBase<AuthorsRepository, Author>
    {
        public AuthorsController(AuthorsRepository repository) : base(repository)
        {
        }
    }
}
