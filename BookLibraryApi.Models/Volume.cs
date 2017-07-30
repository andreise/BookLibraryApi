using BookLibraryApi.Data.Common;
using System.Collections.Generic;

namespace BookLibraryApi.Models
{
    public sealed class Volume : IEntity
    {
        public int? Id { get; set; }

        public int? YearOfPublication { get; set; }

        public int? PageCount { get; set; }

        public IReadOnlyList<Work> Works { get; set; }
    }
}
