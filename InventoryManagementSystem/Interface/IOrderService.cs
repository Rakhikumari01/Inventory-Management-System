using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Interface
{
    public interface IOrderService
    {

        void AddOrder(OrderDto orderDto);
        ViewOrderDto GetOrder(int id);
        void DeleteOrder(int  id);
        void Upadte(int id,OrderDto orderDto);

        

    }
}
