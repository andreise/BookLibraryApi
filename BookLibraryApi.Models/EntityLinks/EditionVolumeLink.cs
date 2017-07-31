using BookLibraryApi.Data.Common;

namespace BookLibraryApi.Models.EntityLinks
{
    public sealed class EditionVolumeLink : IEntity
    {
        public int? Id { get; set; }

        public int? EditionId { get; set; }

        public int? VolumeId { get; set; }
    }
}
