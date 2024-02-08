using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;

namespace InventoryManagementSystem.Models
{
    
        public class ViewOrderDto
        {
            public int Quantity { get; set; }
            public string Status { get; set; }
            public ViewProductDto Product { get; set; }

            public ViewOrderDto() { }

            public ViewOrderDto(Order order, IRepository<Product> _prodrepo)
            {
                Quantity = order.Quantity;
                Status = order.Status;
                Product = new ViewProductDto(_prodrepo.Get(order.ProductId));
            }
        }




    }

