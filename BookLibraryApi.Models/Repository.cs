using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

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

        public virtual void Add(TEntity entity) => this.context.Add(entity);

        public virtual void Add(string entity) => this.Add(JsonConvert.DeserializeObject<TEntity>(entity));

        public virtual void Update(int id, TEntity entity) => this.context.Update(entity);

        public virtual void Update(int id, string entity) => this.Update(id, JsonConvert.DeserializeObject<TEntity>(entity));

        public virtual void Remove(int id) => this.context.Remove(this.Get(id));

        public virtual void SaveChanges() => this.context.SaveChanges();
    }
}
