using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Domain
{
    public class Order:BaseDomain
    {

       

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }


        public Product Product { get; set; }

        public int Quantity { get; set; }

        public String Status { get; set; }
    }
}
