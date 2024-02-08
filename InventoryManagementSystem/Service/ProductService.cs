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
                throw new CustomException("quantity entered is invalid");
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
             if(CheckException(id))
            {
                _productRepository.Delete(id);
            }
            throw new CustomException("product id not found");

        }

        public ViewProductDto GetProduct(int id)
        {
            if(CheckException(id))
            {
                return new ViewProductDto(_productRepository.Get(id));
            }
            throw new CustomException("product id not found");
        }

        public void UpdateProduct(int id, ProductDto prouctDto)
        {
           
            var updateProduct = new Product()
            {
                Id = id,
                ProductName = prouctDto.ProductName,
                Quantity = prouctDto.Quantity,
                Measurement = prouctDto.Measurement,
                CateogeryId = prouctDto.CateogeryId,
            };


             _productRepository.Update(updateProduct);
       
        }

        public bool CheckException(int id)
        {
            var product = _productRepository.Get(id);
            if (product != null)
            {
                return true;
            }
            return false;
        }

        public ICollection<ViewProductDto> GetAllProduct()
        {
            ICollection<ViewProductDto> productList = new List<ViewProductDto>();
            var prods =_productRepository.GetAll(null);
            foreach (var product in prods)
            {
                productList.Add(new ViewProductDto(product));
            }
            return productList;
        }
    }
}
