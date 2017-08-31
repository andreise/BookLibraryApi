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

        protected override ILogger CreateLogger(ILoggerFactory loggerFactory) =>
            loggerFactory.CreateLogger<EntityControllerBase<TEntityRepository, TEntity>>();

        public EntityControllerBase(TEntityRepository repository, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            this.repository = repository;
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
                this.LogInternalServerError(Events.GetCountError, nameof(GetCount), ex);
                return this.InternalServerError();
            }

            return this.Ok(count);
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
                this.LogInternalServerError(Events.GetAllError, nameof(GetAll), ex);
                return this.InternalServerError();
            }

            return this.Ok(entities);
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
                this.LogInternalServerError(Events.GetError, nameof(Get), ex);
                return this.InternalServerError();
            }

            if (entity is null)
                return this.NotFound();

            return this.Ok(entity);
        }

        [HttpPost]
        public IActionResult Post([FromBody]TEntity entity)
        {
            if (entity is null)
                return BadRequest("Entity is null.");

            if (entity.Id != 0)
                return this.BadRequest("Entity ID must be equals to zero.");

            try
            {
                entity = this.repository.Add(entity);
                this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                this.LogInternalServerError(Events.PostError, nameof(Post), ex);
                return this.InternalServerError();
            }

            return this.CreatedAtAction(nameof(Post), entity);
        }

        [HttpPut]
        public IActionResult Put([FromBody]TEntity entity)
        {
            if (entity is null)
                return this.BadRequest("Entity is null.");

            try
            {
                entity = this.repository.Update(entity);

                if (!(entity is null))
                    this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                this.LogInternalServerError(Events.PutError, nameof(Put), ex);
                return this.InternalServerError();
            }

            if (entity is null)
                return this.NotFound();

            return this.Ok(entity);
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
                this.LogInternalServerError(Events.DeleteError, nameof(Delete), ex);
                return this.InternalServerError();
            }

            if (entity is null)
                return this.NotFound();

            return this.Ok();
        }
    }
}
