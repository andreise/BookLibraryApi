using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Models
{
    public sealed class BookLibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Edition> Editions { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Volume> Volumes { get; set; }

        public DbSet<VolumeExemplar> VolumeExemplars { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<WorkKind> WorkKinds { get; set; }

        public BookLibraryContext(DbContextOptions<BookLibraryContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
