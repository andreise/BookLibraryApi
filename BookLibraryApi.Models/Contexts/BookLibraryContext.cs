using BookLibraryApi.Models.Entities;
using BookLibraryApi.Models.EntityLinks;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Models.Contexts
{
    public sealed class BookLibraryContext : DbContext
    {
        // Entities

        public DbSet<Author> Authors { get; set; }

        public DbSet<Edition> Editions { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Volume> Volumes { get; set; }

        public DbSet<VolumeExemplar> VolumeExemplars { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<WorkKind> WorkKinds { get; set; }

        // Entity Links

        public DbSet<EditionVolumeLink> EditionVolumeLinks { get; set; }

        public DbSet<VolumeWorkLink> VolumeWorkLinks { get; set; }

        public DbSet<WorkAuthorLink> WorkAuthorLinks { get; set; }

        public BookLibraryContext(DbContextOptions<BookLibraryContext> options) : base(options)
        {
        }

        // Anemic model is implemented with no validations
        // Possible validations should be implemented in endpoints

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
