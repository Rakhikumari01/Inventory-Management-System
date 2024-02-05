using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using InventoryManagementSystem.NewFolder4;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using System.Net;
using System.Net.Http;
using InventoryManagementSystem.Exceptions;
namespace InventoryManagementSystem.Implementations
{
    public class ProductService : Interface.IProductService  
    {
        public IRepository<Product> _productRepository;
        public IRepository<ProductCateogery> _catrepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(ProductDto prouctDto)
        {
            var q = prouctDto.Quantity;
            if(q < 0)
            {
                throw new EntityNotFoundException("quantity entered is invalid");
            }

            var addProduct = new Product()
            {
                ProductName = prouctDto.ProductName,
                Quantity = prouctDto.Quantity,
                Measurement = prouctDto.Measurement,
                CateogeryId = prouctDto.CateogeryId,
            };

            _productRepository.Add(addProduct);

        }

        public void DeleteProduct(int id)
        {
             CheckException(id);
            _productRepository.Delete(id);

        }

        public ViewProduct GetProduct(int id)
        {
            CheckException(id);
            return new ViewProduct(_productRepository.Get(id));
        }

        public void UpdateProduct(int id, ProductDto prouctDto)
        {
            CheckException(id);
            var updateProduct = new Product()
            {
                Id = id,
                ProductName = prouctDto.ProductName,
                Quantity = prouctDto.Quantity,
                Measurement = prouctDto.Measurement,
                CateogeryId = prouctDto.CateogeryId,
            };


            var entry = _productRepository.Update(updateProduct);
       
        }

        public void CheckException(int id)
        {
            var product = _productRepository.Get(id);
            if (product != null)
            {
                return;
            }

            else
            {
                throw new EntityNotFoundException("product not found");
            }
        }
    }
}
