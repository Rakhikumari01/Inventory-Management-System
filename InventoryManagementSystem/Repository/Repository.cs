using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryManagementSystem.Repository
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseDomain
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

        public void Delete(int id)
        {
            //var entity = _dbContext.Find(tentity);
            _dbContext.Remove(id);
            _dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            var entry = _dbContext.Find<TEntity>(id);
            return entry;
        }

        public TEntity Update(TEntity tentity)
        {
            var entry = _dbContext.Update(tentity);
            _dbContext.SaveChanges();

            return entry.Entity;
        }
    }
}
