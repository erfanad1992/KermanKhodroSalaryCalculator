using KermanKhodro.Infrastructure.EfPersistance.PersonInfos;
using Microsoft.EntityFrameworkCore;

namespace KermanKhodro.Infrastructure.EfPersistance
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonInfoEntityConfiguration());
            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("SqlServerConnectionString",
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
