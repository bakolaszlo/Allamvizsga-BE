using Microsoft.EntityFrameworkCore;
using DataManager.Model;

namespace DataManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Performance> Performances => Set<Performance>();

        public DbSet<DataManager.Model.UserCryptTable> UserCryptTable { get; set; }
    }
}