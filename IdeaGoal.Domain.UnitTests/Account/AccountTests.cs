using System;
using System.Security.Authentication;
using FluentAssertions;
using IdeaGoal.Domain.Core.Data;
using IdeaGoal.Domain.Core.Data.Repo;
using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Account;
using IdeaGoal.Domain.Services.Account.Dto;
using IdeaGoal.Domain.Services.Ideas;
using IdeaGoal.Domain.Services.Security;
using IdeaGoal.Domain.UnitTests.Core;
using IdeaGoal.Domain.UnitTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdeaGoal.Domain.UnitTests.Account
{
    [TestClass]
    public class AccountTests : TestBaseDb
    {
        private AccountService _accountService;

        [TestInitialize()]
        public void Init()
        {
            var db = GetService<IdeaGoalDbContext>();
            DbHelper.CleanDb(db);

            _accountService = GetService<AccountService>();
        }

        [TestMethod]
        public void Should_Login_User()
        {
            // mock data
            var encryptService = GetService<IEncryptService>();
            const string username = "user_1", password = "password_1";
            string passwordHash = encryptService.Encrypt(password, AccountService.AUTH_ENC_KEY);
            var usersRepo = GetService<IRepository<User>>();
            usersRepo.Insert(new User { PasswordHash = passwordHash, Username = username });

            // try login
            var result = _accountService.Login(new LoginDto(username, password));
            result.Should().NotBeNull();
            result.Token.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Should_Throw_Auth_Exception()
        {
            Action login = () => _accountService.Login(new LoginDto { Username = "Grigor", Password = "password" });
            login.Should().Throw<AuthenticationException>().WithMessage("User not authorized");
        }

        [TestMethod]
        public void Should_Work()
        {
            LoginUser();

            var ideService = GetService<IdeasService>();
            ideService.CreateIdea();
        }

        private void LoginUser()
        {
            // mock data
            var encryptService = GetService<IEncryptService>();
            const string username = "user_1", password = "password_1";
            string passwordHash = encryptService.Encrypt(password, AccountService.AUTH_ENC_KEY);
            var usersRepo = GetService<IRepository<User>>();
            usersRepo.Insert(new User { PasswordHash = passwordHash, Username = username });

            _accountService.Login(new LoginDto(username, password));
        }
    }
}
