using System;


namespace InventoryManagementSystem.Exceptions
{
    public class EntityNotFoundException : Exception
    {

        public EntityNotFoundException(string message) : base(message) { }
    }
}
