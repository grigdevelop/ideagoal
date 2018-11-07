using System;
using System.Collections.Generic;
using System.Text;
using IdeaGoal.Domain.Services.Account;

namespace IdeaGoal.Domain.Services.Ideas
{
    public class IdeasService
    {
        private readonly AccountService _accountService;

        public IdeasService(AccountService accountService)
        {
            _accountService = accountService;
        }

        public void CreateIdea()
        {
            if(_accountService.CurrentUser == null)
                throw new Exception("Auth not working right");
        }
    }
}
