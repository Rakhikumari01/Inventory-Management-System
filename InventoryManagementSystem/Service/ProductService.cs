using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using InventoryManagementSystem.NewFolder4;
using InventoryManagementSystem.Repositories;
using System.Net;
using static System.Exception;
namespace InventoryManagementSystem.Implementations
{
    public class ProductService : Interface.IProductService
    {
        public IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(ProductDto prouctDto)
        {
            var addProduct = new Product()
            {
                ProductName = prouctDto.ProductName,
                Quantity = prouctDto.Quantity,
                Measurement = prouctDto.Measurement,
                CateogeryId = prouctDto.CateogeryId,
            };

            if (addProduct.ProductName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _productRepository.Add(addProduct);

        }

        public void DeleteProduct(ProductDto prouctDto)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProduct(ProductDto prouctDto)
        {
            throw new NotImplementedException();
        }

        public ProductDto UpdateProduct(ProductDto prouctDto)
        {
            throw new NotImplementedException();
        }
    }
}
