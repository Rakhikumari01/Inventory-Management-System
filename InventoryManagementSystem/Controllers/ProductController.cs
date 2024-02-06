using InventoryManagementSystem.Domain;
using InventoryManagementSystem.Interface;
using InventoryManagementSystem.IRepository;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.NewFolder4;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Metrics;
using System.Net;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : Controller
    {
        public IProductService _productService;


        public ProductController(IProductService productRepository)
        {
            _productService = productRepository;
        }

        [HttpPost("")]
        public IActionResult AddProductItem([FromBody] ProductDto postDto)
        {

            _productService.AddProduct(postDto);
            return Ok();
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDto productDto)
        {

            _productService.UpdateProduct(id, productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {

            _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ViewProduct GetProduct(int id)
        {
            return _productService.GetProduct(id);

        }
    }
}
