using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Models
{
    public class ViewProduct
    {
        private object product;

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
       

        
        public ViewProduct(Product product)
        {
            ProductName = product.ProductName;
            Measurement = product.Measurement;
            Quantity = product.Quantity;
            
        }

      
    }
}
