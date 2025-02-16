using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new List<Product> {
                    new Product{Id = 1, ProductName = "Iphone 16", Price = 60000, IsActive = true},
                    new Product{Id = 2, ProductName = "Iphone 17", Price = 70000, IsActive = true},
                    new Product{Id = 3, ProductName = "Iphone 17", Price = 80000, IsActive = true}
                }
            );
        }
        public DbSet<Product> Products { get; set; }
    }
}