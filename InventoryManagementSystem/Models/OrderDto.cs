namespace InventoryManagementSystem.Models
{
    public class OrderDto
    {

        public int Quantity { get; set; }

        public String Status { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }
    }
}
