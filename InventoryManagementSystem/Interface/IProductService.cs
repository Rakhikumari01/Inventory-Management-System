
using InventoryManagementSystem.NewFolder4;

namespace InventoryManagementSystem.Interface
{
    public interface IProductService 
    {

        void AddProduct(ProductDto prouctDto);

        ProductDto GetProduct(ProductDto prouctDto);

        ProductDto UpdateProduct(ProductDto prouctDto);

        void DeleteProduct(ProductDto prouctDto);

    }
}
