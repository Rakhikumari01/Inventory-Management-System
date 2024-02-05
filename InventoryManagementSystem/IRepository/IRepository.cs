using InventoryManagementSystem.Domain;
using InventoryManagementSystem.NewFolder4;

namespace InventoryManagementSystem.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// this method adds a Product Cateogery in ProductCateogery table
        /// </summary>
        /// <param name="tentity"></param>
        void Add(TEntity tentity);

        /// <summary>
        /// this method update a Product Cateogery in ProductCateogery table
        /// </summary>
        /// <param name="tentity"></param>
        TEntity Update(TEntity tentity);

        /// <summary>
        /// this method delete a Product Cateogery in ProductCateogery table
        /// </summary>
        /// <param name="tentity"></param>
        void Delete(int id);

        /// <summary>
        /// this method get a Product Cateogery in ProductCateogery table by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(int id);

        public ICollection<TEntity> GetAll(ICollection<int>? ids=null);


    }
}
