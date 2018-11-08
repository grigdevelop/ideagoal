using IdeaGoal.Domain.Services.Account;
using IdeaGoal.Domain.Services.Account.Dto;
using IdeaGoal.Domain.Utilities.Exceptions;

namespace IdeaGoal.Domain.Services
{
    public abstract class ServiceBase
    {
        private readonly IAccountService _accountService;

        protected UserDto CurrentUser => _accountService.CurrentUser;

        protected ServiceBase(IAccountService accountService)
        {
            _accountService = accountService;
        }

        protected virtual void UserAccess()
        {
            if (CurrentUser == null)
                throw new AccessDeniedException();
        }
    }
}
