
using InventoryManagementSystem.Models;
using InventoryManagementSystem.NewFolder4;

namespace InventoryManagementSystem.Interface
{
    public interface IProductService 
    {

        void AddProduct(ProductDto prouctDto);

        ViewProduct GetProduct(int id);

        void UpdateProduct(int id,ProductDto prouctDto);

        void DeleteProduct(int id);

    }
}
