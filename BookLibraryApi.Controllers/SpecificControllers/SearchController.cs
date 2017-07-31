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

        [HttpGet("authors/{authorId}/works")]
        public IReadOnlyList<string> GetWorksByAuthor(int authorId)
        {
            var entities = this.repository.GetWorksByAuthor(authorId);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        [HttpGet("genres/{genreId}/works")]
        public IReadOnlyList<string> GetWorksByGenre(int genreId)
        {
            var entities = this.repository.GetWorksByGenre(genreId);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        [HttpGet("authors/{authorId}/genres/{genreId}/works")]
        public IReadOnlyList<string> GetWorksByAuthorAndGenre(int authorId, int genreId)
        {
            var entities = this.repository.GetWorksByAuthorAndGenre(authorId, genreId);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        [HttpGet("namepattern/{namePattern}/works")]
        public IReadOnlyList<string> GetAuthorsByNamePattern(string namePattern)
        {
            var entities = this.repository.GetAuthorsByNamePattern(namePattern);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }

        [HttpGet("namepattern/{namePattern}/works")]
        public IReadOnlyList<string> GetWorksByNamePattern(string namePattern)
        {
            var entities = this.repository.GetWorksByNamePattern(namePattern);
            return ControllerHelper.SerializeEntities(entities).ToArray();
        }
    }
}
