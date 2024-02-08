
using InventoryManagementSystem.Models;
using InventoryManagementSystem.NewFolder4;

namespace InventoryManagementSystem.Interface
{
    public interface IProductService 
    {

        void AddProduct(ProductDto prouctDto);

        ViewProductDto GetProduct(int id);

        void UpdateProduct(int id,ProductDto prouctDto);

        void DeleteProduct(int id);

        public ICollection<ViewProductDto> GetAllProduct();
    }
}
