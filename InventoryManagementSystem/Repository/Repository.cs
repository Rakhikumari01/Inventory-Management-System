using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryManagementSystem.Repository
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public InventoryDbContext _dbContext;
        public DbSet<TEntity> dbSet { get; set; }

        public Repository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;

          
        }
        public void Add(TEntity tentity)
        {
            _dbContext.Add(tentity);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity tentity)
        {
            //var entity = _dbContext.Find(tentity);
            _dbContext.Remove(tentity);
            _dbContext.SaveChanges();
        }

        public TEntity Get(TEntity tentity)
        {
            var primaryKey = _dbContext.Entry(tentity).Property("CateogeryId").CurrentValue;
            return dbSet.Find(primaryKey);
        }

        public TEntity Update(TEntity tentity)
        {
            var entry = _dbContext.Update(tentity);
            _dbContext.SaveChanges();

            return entry.Entity;
        }
    }
}
