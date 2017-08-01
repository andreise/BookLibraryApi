using BookLibraryApi.Models.Entities.Interfaces;
using System.Collections.Generic;

namespace BookLibraryApi.Models.Entities
{
    public sealed class Edition : IEntityWithNameAndDescription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? VolumeCount { get; set; }
        
        public IReadOnlyList<Volume> Volumes { get; set; }
    }
}
