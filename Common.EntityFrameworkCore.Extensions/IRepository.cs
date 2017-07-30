using System.Collections.Generic;

namespace Common.EntityFrameworkCore.Extensions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IReadOnlyCollection<TEntity> Get();

        TEntity Get(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(int id);

        void SaveChanges();
    }
}
