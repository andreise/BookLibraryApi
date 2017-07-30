using BookLibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    public sealed class AuthorsController : Controller
    {
        private readonly AuthorsRepository repository;

        public AuthorsController(AuthorsRepository repository)
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
            return JsonConvert.SerializeObject(this.repository.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            this.repository.Add(value);
            this.repository.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            this.repository.Update(id, value);
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
