using InventoryManagementSystem.Models;
using InventoryManagementSystem.NewFolder4;

namespace InventoryManagementSystem.Interface
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerDto customerDto);
        CustomerReport GetCustomer(int id);

        void UpdateCustomer(int id, CustomerDto customerDto);

        void DeleteCustomer(int id);

        public CustomerOrderReport GetOrdersByCustomers(int id);


    }
}
