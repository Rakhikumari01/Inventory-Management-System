using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("Product/api")]
    public class ProductController : Controller
    {
        public IRepository<Product> _productRepository;
        

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("addProduct")]
        public IActionResult AddProduct(Product product)
        {
            _productRepository.Add(product);
            return Ok("Product Added Successfully");
        }
    }
}
