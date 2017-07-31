using BookLibraryApi.Data.Common;
using System.Collections.Generic;

namespace BookLibraryApi.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        int GetCount();

        IReadOnlyList<TEntity> GetAll();

        TEntity Get(int id);

        void Add(TEntity entity);

        void Update(int id, TEntity entity);

        void Remove(int id);

        void SaveChanges();
    }
}
