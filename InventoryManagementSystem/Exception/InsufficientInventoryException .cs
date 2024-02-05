using System;

namespace InventoryManagementSystem.Exceptions
{
    public class InsufficientInventoryException : Exception
    {

        public InsufficientInventoryException(string message) : base(message) { }
    }
}
