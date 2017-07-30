using Common.EntityFrameworkCore.Extensions;
using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public abstract class RepositoryBase<TEntity> : Repository<TEntity> where TEntity : class
    {
        public RepositoryBase(BookLibraryContext context) : base(context)
        {
        }
    }
}
