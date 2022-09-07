using BlogApp.Application.Services;

namespace BlogApp.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = "1";
            //httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Subject)
            //?? throw new Exception("Cannot get logged in user id");
        }

        public string UserId { get; }
    }
}
