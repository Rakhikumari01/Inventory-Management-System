using InventoryManagementSystem.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace InventoryManagementSystem.Middlewares
{
    public class CustomMiddleware
    {
         private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next) {
        
          _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {

                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                httpContext.Response.StatusCode = 404;
                var message = ex.Message;
                httpContext.Response.Headers.Append("Error", message);
            }
            catch (Exception)
            {
                httpContext.Response.StatusCode = 500;
                httpContext.Response.Headers.Append("Error", "Something went wrong:(");
            }
        }
    }

    public static class EntityNotFoundMiddlewareExtensions
    {
        public static IApplicationBuilder UseEntityNotFoundMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
