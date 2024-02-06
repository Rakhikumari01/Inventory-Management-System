using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Filters;
using InventoryManagementSystem.Implementations;
using InventoryManagementSystem.Interface;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/order")]
    [CustomExceptionFilter]
    public class OrderController : Controller
    {
        public IOrderService _orderservice;

        public OrderController(IOrderService orderService)
        {
            _orderservice = orderService;
        }


        [HttpPost]
        [Route("")]
        public IActionResult AddOrder(OrderDto orderDto)
        {
            try
            {
                _orderservice.AddOrder(orderDto);
                return Ok();
            }
          catch (InsufficientInventoryException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ViewOrder GetOrderById(int id)
        {
            return _orderservice.GetOrder(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteOrder(int id)
        {

            _orderservice.DeleteOrder(id);
            return Ok();
        }


    }
}
