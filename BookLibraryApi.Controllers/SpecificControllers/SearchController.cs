using BookLibraryApi.Models.Entities;
using BookLibraryApi.Repositories.SpecificRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BookLibraryApi.Controllers.SpecificControllers
{
    [Route("api/[controller]")]
    public sealed class SearchController : Controller
    {
        private readonly bool returnNotFoundOnEmptyList = false;

        private readonly SearchRepository repository;

        private readonly ILogger logger;

        private IActionResult GetActionResult<TEntity>(IReadOnlyList<TEntity> entities) =>
            entities.Count == 0 && this.returnNotFoundOnEmptyList ?
                (IActionResult)NotFound() :
                (IActionResult)Ok(entities);

        public SearchController(SearchRepository repository, ILoggerFactory loggerFactory)
        {
            this.repository = repository;
            this.logger = loggerFactory.CreateLogger<SearchController>();
        }

        [HttpGet("authors/{authorId}/works")]
        public IActionResult GetWorksByAuthor(int authorId)
        {
            IReadOnlyList<Work> entities;

            try
            {
                entities = this.repository.GetWorksByAuthor(authorId);
            }
            catch (Exception ex)
            {
                this.logger.LogError(new EventId(0, $"{nameof(GetWorksByAuthor)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            return GetActionResult(entities);
        }

        [HttpGet("genres/{genreId}/works")]
        public IActionResult GetWorksByGenre(int genreId)
        {
            IReadOnlyList<Work> entities;

            try
            {
                entities = this.repository.GetWorksByGenre(genreId);
            }
            catch (Exception ex)
            {
                this.logger.LogError(new EventId(0, $"{nameof(GetWorksByGenre)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            return GetActionResult(entities);
        }

        [HttpGet("authors/{authorId}/genres/{genreId}/works")]
        public IActionResult GetWorksByAuthorAndGenre(int authorId, int genreId)
        {
            IReadOnlyList<Work> entities;

            try
            {
                entities = this.repository.GetWorksByAuthorAndGenre(authorId, genreId);
            }
            catch (Exception ex)
            {
                this.logger.LogError(new EventId(0, $"{nameof(GetWorksByAuthorAndGenre)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            return GetActionResult(entities);
        }

        [HttpGet("namepattern/{namePattern}/works")]
        public IActionResult GetAuthorsByNamePattern(string namePattern)
        {
            IReadOnlyList<Author> entities;

            try
            {
                entities = this.repository.GetAuthorsByNamePattern(namePattern);
            }
            catch (Exception ex)
            {
                this.logger.LogError(new EventId(0, $"{nameof(GetAuthorsByNamePattern)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            return GetActionResult(entities);
        }

        [HttpGet("namepattern/{namePattern}/works")]
        public IActionResult GetWorksByNamePattern(string namePattern)
        {
            IReadOnlyList<Work> entities;

            try
            {
                entities = this.repository.GetWorksByNamePattern(namePattern);
            }
            catch (Exception ex)
            {
                this.logger.LogError(new EventId(0, $"{nameof(GetWorksByNamePattern)} error"), ex, ex.GetExtendedMessage());
                return StatusCode(500);
            }

            return GetActionResult(entities);
        }
    }
}
