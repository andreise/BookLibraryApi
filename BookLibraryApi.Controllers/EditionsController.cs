using BookLibraryApi.Models;
using BookLibraryApi.Repositories;

namespace BookLibraryApi.Controllers
{
    public sealed class EditionsController : ControllerBase<EditionsRepository, Edition>
    {
        public EditionsController(EditionsRepository repository) : base(repository)
        {
        }
    }
}
