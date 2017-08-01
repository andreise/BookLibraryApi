using BookLibraryApi.Data.Common;
using BookLibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using BookLibraryApi.Models.Entities;
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
        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var entities = this.repository.GetAll();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                // TODO: Log
                return StatusCode(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TEntity entity;

            try
            {
                entity = this.repository.Get(id);
            }
            catch (Exception ex)
            {
                // TODO: Log
                return StatusCode(500);
            }

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            TEntity entity;

            try
            {
                entity = ControllerHelper.DeserializeEntity<TEntity>(value);
            }
            catch (Exception ex)
            {
                // TODO: Log
                return BadRequest();
            }

            try
            {
                entity = this.repository.Add(entity);
                this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Log
                return StatusCode(500);
            }

            return CreatedAtAction(nameof(repository.Add), entity);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            TEntity entity;

            try
            {
                entity = ControllerHelper.DeserializeEntity<TEntity>(value);
            }
            catch (Exception ex)
            {
                // TODO: Log
                return BadRequest();
            }

            try
            {
                this.repository.Update(id, entity);
                this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Log
                return StatusCode(500);
            }

            return CreatedAtAction(nameof(repository.Update), entity);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TEntity entity;

            try
            {
                entity = this.repository.Remove(id);
            }
            catch (Exception ex)
            {
                // TODO: Log
                return StatusCode(500);
            }

            if (entity is null)
                return NotFound();

            return Ok();
        }
    }
}
