using Common.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext context;
        
        public Repository(DbContext context)
        {
            this.context = context;
        }

        public virtual int GetCount() => this.context.Set<TEntity>().Count();

        public virtual IReadOnlyList<TEntity> GetAll() => this.context.Set<TEntity>().ToArray();

        public virtual TEntity Get(int id) => this.context.Find<TEntity>(id);

        public virtual void Add(TEntity entity)
        {
            Contract.RequiresArgumentNotNull(entity, nameof(entity));
            Contract.RequiresArgument(entity.Id is null, "Entity ID must be null.", nameof(entity));

            this.context.Add(entity);
        }

        private static TEntity DeserializeEntity(string entity)
        {
            return JsonConvert.DeserializeObject<TEntity>(entity);
        }

        public virtual void Add(string entity) => this.Add(DeserializeEntity(entity));

        public virtual void Update(int id, TEntity entity)
        {
            Contract.RequiresArgumentNotNull(entity, nameof(entity));
            Contract.RequiresArgument(
                entity.Id is null || entity.Id == id, "Entity ID must be null or equals to the specified ID.", nameof(entity));

            entity.Id = id;
            this.context.Update(entity);
        }

        public virtual void Update(int id, string entity) => this.Update(id, DeserializeEntity(entity));

        public virtual void Remove(int id) => this.context.Remove(this.Get(id));

        public virtual void SaveChanges() => this.context.SaveChanges();
    }
}
