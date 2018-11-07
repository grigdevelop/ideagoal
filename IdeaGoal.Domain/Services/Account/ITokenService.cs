using IdeaGoal.Domain.Core.Entities;

namespace IdeaGoal.Domain.Services.Account
{
    public interface ITokenService
    {
        string GenerateTokenForUser(User user);
        int GetUserID(string token);
    }
}
