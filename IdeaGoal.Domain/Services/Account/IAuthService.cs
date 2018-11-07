using System.Security.Claims;
using System.Threading.Tasks;

namespace IdeaGoal.Domain.Services.Account
{
    public interface IAuthService
    {
        ClaimsPrincipal User { get; }

        Task SignInAsync(ClaimsPrincipal principal);

        Task SignOutAsync();
    }
}
