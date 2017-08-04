using BookLibraryApi.Data.Common;
using BookLibraryApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BookLibraryApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public abstract class EntityControllerBase<TEntityRepository, TEntity> : Controller
        where TEntityRepository : IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly TEntityRepository repository;

        private readonly ILogger logger;

        public EntityControllerBase(TEntityRepository repository, ILoggerFactory loggerFactory)
        {
            this.repository = repository;
            this.logger = loggerFactory?.CreateLogger<EntityControllerBase<TEntityRepository, TEntity>>();
        }

        [Route("count")]
        [HttpGet]
        public IActionResult GetCount()
        {
            try
            {
                var count = this.repository.GetCount();
                return Ok(count);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(new EventId(0, $"{nameof(GetCount)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }
        }

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
                this.logger?.LogError(new EventId(0, $"{nameof(GetAll)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }
        }

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
                this.logger?.LogError(new EventId(0, $"{nameof(Get)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post([FromBody]TEntity entity)
        {
            if (entity is null)
                return BadRequest();

            try
            {
                entity = this.repository.Add(entity);
                this.repository.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                this.logger?.LogError(new EventId(0, $"{nameof(Post)} error"), ex, ex.GetExtendedMessage());
                return BadRequest();
            }
            catch (Exception ex)
            {
                this.logger?.LogError(new EventId(0, $"{nameof(Post)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            return Ok(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TEntity entity)
        {
            if (entity is null)
                return BadRequest();

            TEntity updatedEntity;

            try
            {
                updatedEntity = this.repository.Update(id, entity);

                if (!(updatedEntity is null))
                    this.repository.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                this.logger?.LogError(new EventId(0, $"{nameof(Put)} error"), ex, ex.GetExtendedMessage());
                return BadRequest();
            }
            catch (Exception ex)
            {
                this.logger?.LogError(new EventId(0, $"{nameof(Put)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            if (updatedEntity is null)
                return NotFound();

            return Ok(updatedEntity);
        }

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
                this.logger?.LogError(new EventId(0, $"{nameof(Delete)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            if (entity is null)
                return NotFound();

            return Ok();
        }
    }
}
