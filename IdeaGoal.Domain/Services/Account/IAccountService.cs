using IdeaGoal.Domain.Services.Account.Dto;

namespace IdeaGoal.Domain.Services.Account
{
    public interface IAccountService
    {
        LoginResultDto Login(LoginDto input);

        RegisterResultDto Register(RegisterDto input);

        UserDto CurrentUser { get; }
    }
}
