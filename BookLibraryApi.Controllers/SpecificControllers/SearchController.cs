using BookLibraryApi.Repositories.SpecificRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.Controllers.SpecificControllers
{
    [Route("api/[controller]")]
    public sealed class SearchController : Controller
    {
        private readonly SearchRepository repository;

        public SearchController(SearchRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("works/authors/{authorId}")]
        public IReadOnlyList<string> GetWorksByAuthor([FromBody]int authorId)
        {
            var entities = this.repository.GetWorksByAuthor(authorId);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        [HttpGet("works/genres/{genreId}")]
        public IReadOnlyList<string> GetWorksByGenre([FromBody]int genreId)
        {
            var entities = this.repository.GetWorksByGenre(genreId);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        [HttpGet("works/authors/{authorId}/genres/{genreId}")]
        public IReadOnlyList<string> GetWorksByAuthorAndGenre([FromBody]int authorId, [FromBody]int genreId)
        {
            var entities = this.repository.GetWorksByAuthorAndGenre(authorId, genreId);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        [HttpGet("authors/namepattern/{namePattern}")]
        public IReadOnlyList<string> GetAuthorsByNamePattern([FromBody]string namePattern)
        {
            var entities = this.repository.GetAuthorsByNamePattern(namePattern);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        [HttpGet("works/namepattern/{namePattern}")]
        public IReadOnlyList<string> GetWorksByNamePattern([FromBody]string namePattern)
        {
            var entities = this.repository.GetWorksByNamePattern(namePattern);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }
    }
}
