using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.EntityRepositories;

namespace BookLibraryApi.Controllers.EntityControllers
{
    public sealed class EditionsController : EntityControllerBase<EditionsRepository, Edition>
    {
        public EditionsController(EditionsRepository repository) : base(repository)
        {
        }
    }
}
