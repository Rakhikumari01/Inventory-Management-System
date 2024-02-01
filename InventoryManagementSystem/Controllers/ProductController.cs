using InventoryManagementSystem.Domain;
using InventoryManagementSystem.Interface;
using InventoryManagementSystem.IRepository;
using InventoryManagementSystem.NewFolder4;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Metrics;
using System.Net;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("Product/api")]
    public class ProductController : Controller
    {
        public IProductService _productService;

      
        public ProductController(IProductService productRepository)
        {
            _productService = productRepository;
        }

        [HttpPost]
        [Route("addProduct")]
        public IActionResult AddProductItem([FromBody]ProductDto postDto)
        {
            
            _productService.AddProduct(postDto);
            return Ok("Product Added Successfully");
        }


        /*[HttpPut]
        [Route("updateProduct/{id}")]
        public IActionResult UpdateProduct([FromBody]ProductDto productDto)
        {

            var updatedProduct = new Product()
            {
                ProductName = productDto.ProductName,
                Quantity = productDto.Quantity,
                Measurement = productDto.Measurement,
                CateogeryId = productDto.CateogeryId,
            };
            _productRepository.UpdateProduct(updatedProduct);
            return Ok(updatedProduct);
        }*/
    }
}
