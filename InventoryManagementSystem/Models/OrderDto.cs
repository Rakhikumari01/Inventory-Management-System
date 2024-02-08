using InventoryManagementSystem.Domain;

namespace InventoryManagementSystem.Models
{
    public class OrderDto
    {

        public int Quantity { get; set; }

        public string Status { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }


       
    }
}
