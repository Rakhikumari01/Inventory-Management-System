using System;


namespace InventoryManagementSystem.Exceptions
{
    public class CustomException : Exception
    {

        public CustomException(string message) : base(message) { }
    }
}
