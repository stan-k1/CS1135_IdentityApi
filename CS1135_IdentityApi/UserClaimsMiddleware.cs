using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CS1135_IdentityApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CS1135_IdentityApi
{
    public class UserClaimsMiddleware
    {
        private readonly RequestDelegate _next;

        public UserClaimsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, AppDbContext dbContext)
        {
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                var user = dbContext.Users.FirstOrDefault(u => u.UserName == httpContext.User.Identity.Name);

                var claims = new List<Claim>
                {
                    new Claim("IsActiveFromMiddleware", user.IsActive.ToString())
                };

                var appIdentity = new ClaimsIdentity(claims);
                httpContext.User.AddIdentity(appIdentity);
            }

            await _next(httpContext);
        }
    }

    public static class UserClaimsMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserClaims(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserClaimsMiddleware>();
        }
    }
}
