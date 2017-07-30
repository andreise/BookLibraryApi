using Common.EntityFrameworkCore.Extensions;
using HomeLibraryApi.Models;

namespace HomeLibraryApi.Repositories
{
    public sealed class HomeLibraryRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        public HomeLibraryRepository(HomeLibraryContext context) : base(context)
        {
        }
    }
}
