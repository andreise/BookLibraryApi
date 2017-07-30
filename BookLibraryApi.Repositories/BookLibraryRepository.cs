using Common.EntityFrameworkCore.Extensions;
using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public sealed class BookLibraryRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        public BookLibraryRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
