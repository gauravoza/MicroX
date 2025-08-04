using Microsoft.EntityFrameworkCore;
using MicroX.Domain.Entities;

namespace MicroX.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        // Optional: override OnModelCreating if you want to configure the model with Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // You can customize entity mapping here if needed
        }
    }
}
