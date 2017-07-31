using BookLibraryApi.Data.Common;

namespace BookLibraryApi.Models.EntityLinks
{
    public sealed class VolumeWorkLink : IEntity
    {
        public int? Id { get; set; }

        public int? VolumeId { get; set; }

        public int? WorkId { get; set; }
    }
}
