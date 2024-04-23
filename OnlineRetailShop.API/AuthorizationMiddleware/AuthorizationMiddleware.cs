using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Repository.RImplementations;
using System.Threading.Tasks;

namespace OnlineRetailShop.API.AuthorizationMiddleware
{
    public class AuthorizationMiddleware : IMiddleware
    {
        private readonly IAuthorizationRepository _next;

        public AuthorizationMiddleware(IAuthorizationRepository next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            string ID = httpContext.User.Claims.First(c => c.Type == "ID").Value;
            Guid Userid = Guid.Parse(ID);
            User user = await _next.GetRole(Userid);
            if (user == null)
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.WriteAsync("Unauthorized");
            }
            else await next(httpContext);
        }
    }
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}