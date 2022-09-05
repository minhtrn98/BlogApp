using BlogApp.Application.Services;
using IdentityModel;
using System.Security.Claims;

namespace BlogApp.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Subject);
        }

        public string? UserId { get; }
    }
}
