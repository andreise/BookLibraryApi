using BookLibraryApi.Data.Common;
using BookLibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    public abstract class EntityControllerBase<TEntityRepository, TEntity> : Controller
        where TEntityRepository : IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        private static string SerializeEntity(TEntity entity)
        {
            return JsonConvert.SerializeObject(entity);
        }

        private static TEntity DeserializeEntity(string entity)
        {
            return JsonConvert.DeserializeObject<TEntity>(entity);
        }

        private readonly TEntityRepository repository;

        public EntityControllerBase(TEntityRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IReadOnlyList<string> Get()
        {
            return this.repository.GetAll().Select(item => JsonConvert.SerializeObject(item)).ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return SerializeEntity(this.repository.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var entity = DeserializeEntity(value);

            this.repository.Add(entity);
            this.repository.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            var entity = DeserializeEntity(value);

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
