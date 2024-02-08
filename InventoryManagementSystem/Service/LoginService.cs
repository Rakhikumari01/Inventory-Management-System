using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Service
{
    public class LoginService : Interface.ILoginService
    {
      

        public bool IsValidUser(string email, string password)
        {
            
          
            return email == "rakhi6602@gmail.com" && password == "0125";
        }

       
        public string GetJwtKey()
        {
            
          return  "MyInventoeyManagementSystemApplicationSecretKey";
        }

        
        public string GetJwtIssuer()
        {
           return  "InventoryManagementSystem";
        }
    }
}
