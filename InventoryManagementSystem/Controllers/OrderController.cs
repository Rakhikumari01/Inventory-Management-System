using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Filters;
using InventoryManagementSystem.Implementations;
using InventoryManagementSystem.Interface;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/order")]
    [CustomExceptionFilter]
    [Authorize]
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
            _orderservice.AddOrder(orderDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public ViewOrderDto GetOrderById(int id)
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

        [HttpPut]
        public IActionResult UpdateOrder(int id,OrderDto orderDto)
        {
            _orderservice.Upadte(id,orderDto);
            return Ok();
        }

    }
}
