using Microsoft.EntityFrameworkCore;

namespace HomeLibraryApi.Models
{
    public sealed class HomeLibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Edition> Editions { get; set; }

        public DbSet<Volume> Volumes { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<WorkKind> WorkKinds { get; set; }

        public HomeLibraryContext(DbContextOptions<HomeLibraryContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
