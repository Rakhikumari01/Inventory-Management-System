using InventoryManagementSystem.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InventoryManagementSystem.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is InsufficientInventoryException)
            {
                context.HttpContext.Response.StatusCode = 400; 
                var message = context.Exception.Message;
                context.Result = new JsonResult(new { error = message });
            }
        }
    }
}
