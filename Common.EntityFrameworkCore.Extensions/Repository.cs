using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Common.EntityFrameworkCore.Extensions
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        
        public Repository(DbContext context)
        {
            this.context = context;
        }

        public virtual IReadOnlyCollection<TEntity> Get() => this.context.Set<TEntity>().ToArray();

        public virtual TEntity Get(int id) => this.context.Find<TEntity>(id);

        public virtual void Add(TEntity entity) => this.context.Add(entity);

        public virtual void Update(TEntity entity) => this.context.Update(entity);

        public virtual void Remove(int id) => this.context.Remove(this.Get(id));

        public virtual void SaveChanges() => this.context.SaveChanges();
    }
}
