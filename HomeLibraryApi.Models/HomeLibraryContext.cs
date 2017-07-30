using Microsoft.EntityFrameworkCore;

namespace HomeLibraryApi.Models
{
    public sealed class HomeLibraryContext : DbContext
    {
        public HomeLibraryContext(DbContextOptions<HomeLibraryContext> options): base(options)
        {
        }
    }
}
