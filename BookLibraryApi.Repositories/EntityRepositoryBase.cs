using BookLibraryApi.Data.Common;
using Common.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.Repositories
{
    public abstract class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext context;
        
        public EntityRepositoryBase(DbContext context)
        {
            this.context = context;
        }

        public virtual int GetCount() => this.context.Set<TEntity>().Count();

        public virtual IReadOnlyList<TEntity> GetAll() => this.context.Set<TEntity>().ToArray();

        public virtual TEntity Get(int id) => this.context.Find<TEntity>(id);

        public virtual TEntity Add(TEntity entity)
        {
            Contract.RequiresArgumentNotNull(entity, nameof(entity));
            Contract.RequiresArgument(entity.Id is null, "Entity ID must be null.", nameof(entity));

            return this.context.Add(entity).Entity;
        }

        public virtual TEntity Update(int id, TEntity entity)
        {
            Contract.RequiresArgumentNotNull(entity, nameof(entity));
            Contract.RequiresArgument(
                entity.Id is null || entity.Id == id, "Entity ID must be null or equals to the specified ID.", nameof(entity));

            if (this.Get(id) is null)
                return null;

            entity.Id = id;
            return this.context.Update(entity).Entity;
        }

        public virtual TEntity Remove(int id)
        {
            var entity = this.Get(id);

            if (entity is null)
                return null;

            return this.context.Remove(entity).Entity;
        }

        public virtual void SaveChanges() => this.context.SaveChanges();
    }
}
