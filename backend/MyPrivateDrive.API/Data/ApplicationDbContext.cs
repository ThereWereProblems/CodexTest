using Microsoft.EntityFrameworkCore;
using MyPrivateDrive.API.Models;

namespace MyPrivateDrive.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<FileRecord> Files => Set<FileRecord>();
    }
}
