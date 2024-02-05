using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Domain
{
    public class Customer:BaseDomain
    {
      
        public String FistName { get; set; }
        public String LastName { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        public string PhoneNumber {  get; set; }
    }
}
