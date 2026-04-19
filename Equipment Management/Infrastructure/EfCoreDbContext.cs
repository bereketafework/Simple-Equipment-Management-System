using Equipment_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace Equipment_Management.Infrastructure
{
    // A Class that use To Create a Databased by Using EntityFramework 
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options): base(options)
        {
        }
    // Used To Map Enum to Database data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().Property(e => e.Status).IsRequired();
        }

        public DbSet<Equipment> Equipment { get; set; }
    }

}
