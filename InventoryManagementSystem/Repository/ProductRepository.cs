using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repository
{
    public class ProductRepository<Product> : IRepository<Product> where Product : class
    {
        public InventoryDbContext DbContext;
        public DbSet<Product> Products { get; set; }

        public ProductRepository(InventoryDbContext dbContext)
        {
            DbContext = dbContext;
            Products = DbContext.Set<Product>();
        }
        public void Add(Product product)
        {
            Products.Add(product);
            DbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var entity = Products.Find(Id);
            Products.Remove(entity);
            DbContext.SaveChanges();
        }

        public Product GetProduct(int Id)
        {
            return Products.Find(Id);
            
        }

        public Product Update(Product product)
        {
            var entry = Products.Update(product);
            DbContext.SaveChanges();

            return entry.Entity;
        }
    }
}
