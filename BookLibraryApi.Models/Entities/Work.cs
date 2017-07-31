using BookLibraryApi.Models.Entities.Interfaces;
using System.Collections.Generic;

namespace BookLibraryApi.Models.Entities
{
    public sealed class Work : IEntityWithNameAndDescription
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? YearOfCompletion { get; set; }

        public int? YearOfFirstPublication { get; set; }

        public IReadOnlyList<Author> Authors { get; set; }

        public int? WorkKindId { get; set; }

        public WorkKind WorkKind { get; set; }

        public int? AltWorkKindId { get; set; }

        public WorkKind AltWorkKind { get; set; }

        public int? GenreId { get; set; }

        public Genre Genre { get; set; }

        public int? AltGenreId { get; set; }

        public Genre AltGenre { get; set; }
    }
}
