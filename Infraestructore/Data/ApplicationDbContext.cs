using Core.Entities;
using Infraestructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> User { get; set; }
    }
}
