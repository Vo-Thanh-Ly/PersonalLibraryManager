using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PersonalLibraryManager.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }
        // Constructor không tham số (cho design-time)
        public LibraryContext()
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}
