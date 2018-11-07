using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Account.Dto;

namespace IdeaGoal.Domain.Services.Account
{
    public interface ITokenService
    {
        string GenerateTokenForUser(UserDto user);
        int GetUserID(string token);
    }
}
