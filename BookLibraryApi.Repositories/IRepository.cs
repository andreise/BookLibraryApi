using BookLibraryApi.Data.Common;
using System.Collections.Generic;

namespace BookLibraryApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        int GetCount();

        IReadOnlyList<TEntity> GetAll();

        TEntity Get(int id);

        void Add(TEntity entity);

        void Add(string entity);

        void Update(int id, TEntity entity);

        void Update(int id, string entity);

        void Remove(int id);

        void SaveChanges();
    }
}
