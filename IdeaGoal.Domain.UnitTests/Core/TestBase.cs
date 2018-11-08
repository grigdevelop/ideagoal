using System;
using IdeaGoal.Domain.Core.Data;
using IdeaGoal.Domain.Core.Data.Repo;
using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Account;
using IdeaGoal.Domain.Services.Account.Dto;
using IdeaGoal.Domain.Services.Ideas;
using IdeaGoal.Domain.Services.Security;
using IdeaGoal.Domain.Services.Utilities;
using IdeaGoal.Domain.UnitTests.Mock.Services;
using IdeaGoal.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdeaGoal.Domain.UnitTests.Core
{
    [TestClass]
    public abstract class TestBase
    {
        private IServiceProvider _serviceProvider;
        private static bool _initialized = false;

        protected TestBase()
        {
            ConfigureBindings();
            if (!_initialized)
            {
                OneTimeConfigurations();
                _initialized = true;
            }
        }

        private void OneTimeConfigurations()
        {
            MapperExtensions.Configure();
        }

        private void ConfigureBindings()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(CreateDbInstance());
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<ICacheService, CacheServiceMock>();
            serviceCollection.AddScoped<IAccountService, AccountService>();
            serviceCollection.AddScoped<IEncryptService, EncryptDecryptService>();
            serviceCollection.AddScoped<IAuthService, AuthServiceMock>();
            serviceCollection.AddScoped<ITokenService, SqlTokenService>();
            serviceCollection.AddScoped<IIdeaService, IdeasService>();

            _serviceProvider = serviceCollection.BuildServiceProvider();            
        }

        protected TService GetService<TService>()
        {
            return _serviceProvider.GetService<TService>();
        }

        private IdeaGoalDbContext CreateDbInstance()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=IdeaGoal.Database;Integrated Security=True;Pooling=False;Connect Timeout=30");
            return new IdeaGoalDbContext(builder.Options);
        }

        protected User AuthorizeUser()
        {
            // mock data
            var encryptService = GetService<IEncryptService>();
            const string username = "user_1", password = "password_1";
            string passwordHash = encryptService.Encrypt(password, AccountService.AUTH_ENC_KEY);
            var usersRepo = GetService<IRepository<User>>();
            var user = usersRepo.Insert(new User { PasswordHash = passwordHash, Username = username });

            GetService<IAccountService>().Login(new LoginDto(username, password));

            return user;
        }
    }
}
