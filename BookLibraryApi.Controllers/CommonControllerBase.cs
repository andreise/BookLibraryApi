using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApi.Controllers
{
    public abstract class CommonControllerBase : Controller
    {
        public virtual StatusCodeResult InternalServerError() => StatusCode(500);
    }
}
