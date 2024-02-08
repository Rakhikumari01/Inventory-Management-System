using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Repositories;
using InventoryManagementSystem.Interface;

namespace InventoryManagementSystem.Service
{
    public class CustomerService : Interface.ICustomerService
    {
        public IRepository<Customer> _customerRepository;
        public IRepository<Order> _orderRepository;
        public IRepository<Product> _productRepository;


        public CustomerService(IRepository<Customer> customerRepository, IRepository<Order> orderRepository, IRepository<Product> productRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public void AddCustomer(CustomerDto customerDto)
        {
            var addCustomer = new Customer()
            {
                FistName = customerDto.FirstName,
                LastName = customerDto.LastName,
                email = customerDto.email,
                Password = customerDto.Password,
                PhoneNumber = customerDto.PhoneNumber,
            };

            _customerRepository.Add(addCustomer);
        }

        public void DeleteCustomer(int id)
        {
            if (CheckEntityNotFound(id))
            {
                _customerRepository.Delete(id);
            }
            else throw new CustomException("Customer id not found");
        }

        public CustomerReport GetCustomer(int id)
        {
            if(CheckEntityNotFound(id))
            {
                return new CustomerReport(_customerRepository.Get(id));
            }
            else throw new CustomException("Customer id not found");
        }

        public void UpdateCustomer(int id, CustomerDto customerDto)
        {  
            var updateCustomer = new Customer()

            {
                Id = id,
                FistName = customerDto.FirstName,
                LastName = customerDto.LastName,
                email = customerDto.email,
                Password = customerDto.Password,
                PhoneNumber = customerDto.PhoneNumber,
            };


           _customerRepository.Update(updateCustomer);
           
        }

        public CustomerOrderReport GetOrdersByCustomers(int id)
        {
            if(CheckEntityNotFound(id))
            {

                var customer = _customerRepository.Get(id);

                if (customer != null)
                {
                    var ordersForCustomer = _orderRepository.GetAll().Where(c => c.CustomerId == id).ToList();
                    var c = new CustomerOrderReport(customer, ordersForCustomer, _productRepository);

                    return c;
                }
                else
                {
                    return null;
                }
            }

            else throw new CustomException("Customer id not found");

        }


        public bool CheckEntityNotFound(int id)
        {
            var customer = _customerRepository.Get(id);
            if (customer != null)
            {
                return true;
            }

            return false;
        }

      
    }
}
