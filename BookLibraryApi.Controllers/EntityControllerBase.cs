using BookLibraryApi.Models.Entities.Interfaces;
using BookLibraryApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BookLibraryApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public abstract class EntityControllerBase<TEntityRepository, TEntity> : CommonControllerBase
        where TEntityRepository : IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        private static class Events
        {
            public const int GetCountError = 0;
            public const int GetAllError = 1;
            public const int GetError = 2;
            public const int PostError = 3;
            public const int PutError = 4;
            public const int DeleteError = 5;
        }

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
            int count;

            try
            {
                count = this.repository.GetCount();
            }
            catch (Exception ex)
            {
                this.logger?.LogError(new EventId(Events.GetCountError, $"{nameof(GetCount)} error"), ex, ex.GetExtendedMessage());
                return InternalServerError();
            }

            return Ok(count);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            IReadOnlyList<TEntity> entities;

            try
            {
                entities = this.repository.GetAll();
            }
            catch (Exception ex)
            {
                this.logger?.LogError(new EventId(Events.GetAllError, $"{nameof(GetAll)} error"), ex, ex.GetExtendedMessage());
                return InternalServerError();
            }

            return Ok(entities);
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
                this.logger?.LogError(new EventId(Events.GetError, $"{nameof(Get)} error"), ex, ex.GetExtendedMessage());
                return InternalServerError();
            }

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post([FromBody]TEntity entity)
        {
            if (entity is null)
                return BadRequest("Entity is null.");

            if (entity.Id != 0)
                return BadRequest("Entity ID must be equals to zero.");

            try
            {
                entity = this.repository.Add(entity);
                this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger?.LogError(new EventId(Events.PostError, $"{nameof(Post)} error"), ex, ex.GetExtendedMessage());
                return InternalServerError();
            }

            return CreatedAtAction(nameof(Post), entity);
        }

        [HttpPut]
        public IActionResult Put([FromBody]TEntity entity)
        {
            if (entity is null)
                return BadRequest("Entity is null.");

            try
            {
                entity = this.repository.Update(entity);

                if (!(entity is null))
                    this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger?.LogError(new EventId(Events.PutError, $"{nameof(Put)} error"), ex, ex.GetExtendedMessage());
                return InternalServerError();
            }

            if (entity is null)
                return NotFound();

            return Ok(entity);
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
                this.logger?.LogError(new EventId(Events.DeleteError, $"{nameof(Delete)} error"), ex, ex.GetExtendedMessage());
                return InternalServerError();
            }

            if (entity is null)
                return NotFound();

            return Ok();
        }
    }
}
