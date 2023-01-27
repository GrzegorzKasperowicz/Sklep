using Microsoft.EntityFrameworkCore;

namespace Sklep.Data.Model
{
    public class SklepDbContext : DbContext
    {
        public SklepDbContext(DbContextOptions<SklepDbContext> options)
      : base(options)
        {
        }

        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductProducer> ProductProducer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
      
    }
}

