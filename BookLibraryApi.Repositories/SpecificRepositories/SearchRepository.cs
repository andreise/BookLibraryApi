using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.Entities;
using BookLibraryApi.Models.Entities.Interfaces;
using BookLibraryApi.Models.EntityLinks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.Repositories.SpecificRepositories
{
    public sealed class SearchRepository
    {
        private readonly BookLibraryContext context;

        public SearchRepository(BookLibraryContext context)
        {
            this.context = context;
        }

        private IQueryable<WorkAuthorLink> GetWorkAuthorLinksByAuthorInternal(int authorId) =>
            this.context.Set<WorkAuthorLink>()
            .Where(item => item.AuthorId == authorId);

        private IQueryable<Work> GetWorksByAuthorInternal(int authorId)
        {
            var workAuthorLinksByAuthor = this.GetWorkAuthorLinksByAuthorInternal(authorId);
            var works = this.context.Set<Work>();

            return workAuthorLinksByAuthor.Join(
                works,
                outer => outer.WorkId,
                inner => inner.Id,
                (outer, inner) => inner);
        }

        private IQueryable<Work> GetWorksByGenreInternal(int genreId) =>
            this.context.Set<Work>()
            .Where(item => new[] { item.GenreId, item.AltGenreId }.Contains(genreId));

        private IQueryable<Work> GetWorksByAuthorAndGenreInternal(int authorId, int genreId)
        {
            var workAuthorLinksByAuthor = this.GetWorkAuthorLinksByAuthorInternal(authorId);
            var worksByGenre = this.GetWorksByGenreInternal(genreId);

            return workAuthorLinksByAuthor.Join(
                worksByGenre,
                outer => outer.WorkId,
                inner => inner.Id,
                (outer, inner) => inner);
        }

        private static string[] SplitNameInternal(string name) =>
            name.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

        private static bool IsMatchNameInternal(string[] pattern, string name)
        {
            string[] nameItems = SplitNameInternal(name);

            return pattern.All(
                patternItem => nameItems.Any(
                    nameItem => nameItem.StartsWith(patternItem, StringComparison.OrdinalIgnoreCase)));
        }

        private IQueryable<TEntity> GetEntitiesByNamePatternInternal<TEntity>(string namePattern)
            where TEntity : class, IEntityWithName
        {
            if (string.IsNullOrWhiteSpace(namePattern))
                return Enumerable.Empty<TEntity>().AsQueryable();

            string[] pattern = SplitNameInternal(namePattern);

            return this.context.Set<TEntity>()
                .Where(item => !string.IsNullOrWhiteSpace(item.Name))
                .Where(item => IsMatchNameInternal(pattern, item.Name));
        }

        public IReadOnlyList<Work> GetWorksByAuthor(int authorId) =>
            this.GetWorksByAuthorInternal(authorId).ToArray();

        public IReadOnlyList<Work> GetWorksByGenre(int genreId) =>
            this.GetWorksByGenreInternal(genreId).ToArray();

        public IReadOnlyList<Work> GetWorksByAuthorAndGenre(int authorId, int genreId) =>
            this.GetWorksByAuthorAndGenreInternal(authorId, genreId).ToArray();

        public IReadOnlyList<Author> GetAuthorsByNamePattern(string namePattern) =>
            this.GetEntitiesByNamePatternInternal<Author>(namePattern).ToArray();

        public IReadOnlyList<Work> GetWorksByNamePattern(string namePattern) =>
            this.GetEntitiesByNamePatternInternal<Work>(namePattern).ToArray();
    }
}
