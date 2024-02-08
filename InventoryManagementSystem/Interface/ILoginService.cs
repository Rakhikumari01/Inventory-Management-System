using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Interface
{
    public interface ILoginService
    {

        bool IsValidUser(string username, string password);
        string GetJwtKey();
        string GetJwtIssuer();
    }
}
