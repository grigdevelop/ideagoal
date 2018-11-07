using IdeaGoal.Domain.Services.Account;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdeaGoal.Domain.UnitTests.Mock.Services
{
    public class AuthServiceMock : IAuthService
    {
        public HttpContext HttpContext { get; set; }

        public AuthServiceMock()
        {
            HttpContext = new DefaultHttpContext();
        }

        public ClaimsPrincipal User { get; private set; }

        public Task SignInAsync(ClaimsPrincipal principal)
        {
            return Task.Run(() => { User = principal; });
        }

        public Task SignOutAsync()
        {
            return Task.Run(() => { User = null; });
        }
    }
}
