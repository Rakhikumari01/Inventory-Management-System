using InventoryManagementSystem.Interface;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.NewFolder4;
using InventoryManagementSystem.Implementations;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        public ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]

        public IActionResult AddCustomerController(CustomerDto customerDto)
        {

            _customerService.AddCustomer(customerDto);
            return Ok();
        }

        [HttpPatch]

        public IActionResult UpdateCustomerController(int id, CustomerDto customerDto)
        {
            _customerService.UpdateCustomer(id, customerDto);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {

            _customerService.DeleteCustomer(id);
            return Ok();
        }

        [HttpGet("get/{id}")]
        public CustomerReport GetCustomerById(int id)
        {
            return _customerService.GetCustomer(id);
        }

        
    }
}
