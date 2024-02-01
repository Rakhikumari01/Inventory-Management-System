using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/ProductCateogery/")]
    public class ProductCateogeryController :Controller
    {
        public  IRepository<ProductCateogery> _productCateogeryRepository;

        public ProductCateogeryController(IRepository<ProductCateogery> productCateogeryRepository)
        {
            _productCateogeryRepository = productCateogeryRepository;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddProductCateogery(ProductCateogery productCateogery)
        {
            _productCateogeryRepository.Add(productCateogery);
            return Ok("ProductCateogery Added Successfully");
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteProductCateogery(int id)
        {
            _productCateogeryRepository.Delete(id);
            return Ok("ProductCteogery is deleted");
        }

        [HttpGet]
        [Route("get/productCateogeryById")]
        public IActionResult getProductCateogeryById(int id)
        {
            var pc = _productCateogeryRepository.Get(id);
            return Ok(pc);
        }

        [HttpPut]
        [Route("update/ProductCateogery")]
        public IActionResult UpdateProductCateogery(ProductCateogery productCateogery)
        {
            var entry = _productCateogeryRepository.Update(productCateogery);
            return Ok(entry);
        }
    }
}
