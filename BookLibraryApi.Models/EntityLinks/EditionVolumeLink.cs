using BookLibraryApi.Data.Common;
using BookLibraryApi.Models.Entities;

namespace BookLibraryApi.Models.EntityLinks
{
    public sealed class EditionVolumeLink : IEntity
    {
        public int? Id { get; set; }

        public int? EditionId { get; set; }

        public Edition Edition { get; set; }

        public int? VolumeId { get; set; }

        public Volume Volume { get; set; }
    }
}
