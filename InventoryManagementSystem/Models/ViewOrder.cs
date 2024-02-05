using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;

namespace InventoryManagementSystem.Models
{
    
        public class ViewOrder
        {
            public int Quantity { get; set; }
            public string Status { get; set; }
            public ViewProduct Product { get; set; }

            public ViewOrder() { }

            public ViewOrder(Order order, IRepository<Product> _prodrepo)
            {
                Quantity = order.Quantity;
                Status = order.Status;
                Product = new ViewProduct(_prodrepo.Get(order.ProductId));
            }
        }




    }

