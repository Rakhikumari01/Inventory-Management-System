using InventoryManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }
        public DbSet<ProductCateogery> ProductCateogery { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

    }
}
