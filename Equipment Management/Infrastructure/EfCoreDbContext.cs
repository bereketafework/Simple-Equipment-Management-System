using Equipment_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace Equipment_Management.Infrastructure
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().Property(e => e.Status).IsRequired();
        }

        public DbSet<Equipment> Equipment { get; set; }
    }

}
