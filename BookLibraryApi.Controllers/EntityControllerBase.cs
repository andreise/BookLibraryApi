using BookLibraryApi.Data.Common;
using BookLibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    public abstract class EntityControllerBase<TEntityRepository, TEntity> : Controller
        where TEntityRepository : IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly TEntityRepository repository;

        public EntityControllerBase(TEntityRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IReadOnlyList<string> Get()
        {
            var entities = this.repository.GetAll();
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return ControllerHelper.SerializeEntity(this.repository.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var entity = ControllerHelper.DeserializeEntity<TEntity>(value);

            this.repository.Add(entity);
            this.repository.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            var entity = ControllerHelper.DeserializeEntity<TEntity>(value);

            this.repository.Update(id, entity);
            this.repository.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.repository.Remove(id);
        }
    }
}
