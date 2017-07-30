using System.Collections.Generic;

namespace HomeLibraryApi.Models
{
    public sealed class Volume : IEntity
    {
        public int Id { get; set; }

        public int? YearOfPublication { get; set; }

        public int? PageCount { get; set; }

        public IReadOnlyList<Work> Works { get; set; }
    }
}
