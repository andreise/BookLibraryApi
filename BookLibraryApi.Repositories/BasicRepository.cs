using Common.EntityFrameworkCore.Extensions;
using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class BasicRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        public BasicRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
