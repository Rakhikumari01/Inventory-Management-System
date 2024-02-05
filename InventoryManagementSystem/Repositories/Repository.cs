using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace InventoryManagementSystem.Repositories
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
            var entry = _dbContext.Find<TEntity>(id);
            _dbContext.Remove(entry);
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

        public ICollection<TEntity> GetAll(ICollection<int>? ids=null)
        {
            ICollection<TEntity> list = new List<TEntity>();
            if (ids != null)
            {
                foreach (var id in ids)
                {
                    list.Add(Get(id));
                }
            }
            else
            {
                list = _dbContext.Set<TEntity>().Where(t => t.Id != 0).ToList();
            }
            return list;
        }
    }
}
