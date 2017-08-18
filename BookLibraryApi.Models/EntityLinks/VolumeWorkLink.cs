using BookLibraryApi.Models.Entities;
using BookLibraryApi.Models.Entities.Interfaces;

namespace BookLibraryApi.Models.EntityLinks
{
    public sealed class VolumeWorkLink : IEntity
    {
        public int Id { get; set; }

        public int VolumeId { get; set; }

        public Volume Volume { get; set; }

        public int WorkId { get; set; }

        public Work Work { get; set; }
    }
}
