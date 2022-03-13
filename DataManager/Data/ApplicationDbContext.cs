using Microsoft.EntityFrameworkCore;
using DataManager.Model;

namespace DataManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                var originalConnectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
                if (originalConnectionString != null)
                {
                    try
                    {
                        connectionString = StartupHelper.GetHerokuConnectionString(originalConnectionString);
                    }
                    catch (Exception exc)
                    {
                        // throw new Exception($"Cannot parse connection string from {originalConnectionString}.", exc);
                    }
                }
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbSet<Performance> Performances => Set<Performance>();

        public DbSet<DataManager.Model.UserCryptTable> UserCryptTable { get; set; }
    }
}