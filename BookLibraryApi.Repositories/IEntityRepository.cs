using BookLibraryApi.Data.Common;
using System.Collections.Generic;

namespace BookLibraryApi.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        int GetCount();

        IReadOnlyList<TEntity> GetAll();

        TEntity Get(int id);

        TEntity Add(TEntity entity);

        TEntity Update(int id, TEntity entity);

        TEntity Remove(int id);

        void SaveChanges();
    }
}
