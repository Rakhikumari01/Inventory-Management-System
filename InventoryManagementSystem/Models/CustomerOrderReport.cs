using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;

namespace InventoryManagementSystem.Models
{
    public class CustomerOrderReport
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string email { get; set; }

        public ICollection<ViewOrder> Orders { get; set; }

        public CustomerOrderReport(Customer customer,ICollection<Order> orders, IRepository<Product> _prodRepo)
        {
            ICollection<ViewOrder> viewOrders = new List<ViewOrder>();
              foreach(var  o in orders)
            {
                viewOrders.Add(new ViewOrder(o, _prodRepo));
            }
            FistName = customer.FistName;
            LastName = customer.LastName;
            PhoneNumber = customer.PhoneNumber;
            email = customer.email;
            Orders = viewOrders;

        }
    }
}
