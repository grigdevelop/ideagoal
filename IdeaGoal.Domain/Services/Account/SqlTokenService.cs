using IdeaGoal.Domain.Core.Data.Repo;
using IdeaGoal.Domain.Core.Entities;
using System;
using System.Linq;
using System.Security.Authentication;

namespace IdeaGoal.Domain.Services.Account
{
    public class SqlTokenService : ITokenService
    {
        private readonly IRepository<UserToken> _userTokenRepository;

        public SqlTokenService(IRepository<UserToken> userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }

        public string GenerateTokenForUser(User user)
        {
            string token = Guid.NewGuid().ToString();
            UserToken ut = new UserToken { Token = token, UserId = user.Id };
            _userTokenRepository.Insert(ut);
            return token;
        }

        public int GetUserID(string token)
        {
            var userToken = _userTokenRepository.Table.FirstOrDefault(x => x.Token == token);
            if(userToken == null) throw new AuthenticationException("Token not authorized.");

            return userToken.UserId;
        }
    }
}
