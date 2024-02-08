using InventoryManagementSystem.Interface;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("Report")]
    public class CustomerOrderController : Controller
    {
        public ICustomerService _customerService;

        public CustomerOrderController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("Order/Customer/{id}")]
        public CustomerOrderReport GetOrderCustomerView(int id)
        {
            return _customerService.GetOrdersByCustomers(id);
        }
    }
}
