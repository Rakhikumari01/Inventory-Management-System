namespace InventoryManagementSystem.IRepository
{
    public interface IProductRepository<Product> where Product : class
    {
        void Add(Product product);
        Product Update(Product product);
        Product GetProduct(int Id);
        void Delete(int Id);
    }
}
