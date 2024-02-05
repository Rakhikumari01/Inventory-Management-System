using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Interface
{
    public interface IOrderService
    {

        void AddOrder(OrderDto orderDto);
        ViewOrder GetOrder(int id);
        void DeleteOrder(int  id);
    }
}
