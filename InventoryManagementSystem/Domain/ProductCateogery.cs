using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Domain
{
    public class ProductCateogery
    {

        [Key]
        public int CateogeryId { get; set; }

        public String Name { get; set; }

      

       // public List<Product> products { get; set; }
    }
}
