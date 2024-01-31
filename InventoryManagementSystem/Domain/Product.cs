using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Domain
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        public String ProductName { get; set; }

        public int Quantity { get; set; }

        public String Measurement { get; set; }

        [ForeignKey("ProductCateogery")]
        public int CateogeryId { get; set; }

        public ProductCateogery ProductCateogery { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
