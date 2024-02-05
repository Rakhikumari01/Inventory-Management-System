using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using System.Diagnostics.Metrics;

namespace InventoryManagementSystem.Models
{
    public class CustomerReport
    {
        public string FistName {  get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public CustomerReport() { }

      
        public CustomerReport(Customer customer)
        {
            FistName = customer.FistName;
            LastName = customer.LastName;
            PhoneNumber = customer.PhoneNumber;

        }

    }
}
