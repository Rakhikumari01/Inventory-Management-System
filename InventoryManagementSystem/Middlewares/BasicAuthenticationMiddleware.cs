using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;

namespace InventoryManagementSystem.Middlewares
{
    public class BasicAuthenticationMiddleware
    {

        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
                string authHeader = context.Request.Headers["Authorization"];

                if (authHeader != null && authHeader.StartsWith("Basic"))
                {
                    
                    string encodedUsernamePassword = authHeader.Substring("Basic".Length).Trim();
                

                    if (IsAuthorized(encodedUsernamePassword))
                    {
                        await _next.Invoke(context);
                        return;
                    }
                }

                
                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized User");
            
            
        }

        private bool IsAuthorized(string key)
        {
            return key == "cmFraGk2NjAyOjEyMzQ=";
        }
    }


    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}

