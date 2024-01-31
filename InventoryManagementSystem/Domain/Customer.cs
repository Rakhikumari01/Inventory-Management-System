using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Domain
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public String FistName { get; set; }
        public String LastName { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
