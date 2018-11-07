using System;
using IdeaGoal.Domain.Core.Data;
using IdeaGoal.Domain.Core.Data.Repo;
using IdeaGoal.Domain.Services.Account;
using IdeaGoal.Domain.Services.Ideas;
using IdeaGoal.Domain.Services.Security;
using IdeaGoal.Domain.Services.Utilities;
using IdeaGoal.Domain.UnitTests.Mock.Services;
using IdeaGoal.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdeaGoal.Domain.UnitTests.Core
{
    public abstract class TestBase
    {
        private IServiceProvider _serviceProvider;

        protected TestBase()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(CreateDbInstance());
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<ICacheService, CacheServiceMock>();
            serviceCollection.AddScoped<AccountService>();
            serviceCollection.AddScoped<IEncryptService, EncryptDecryptService>();
            serviceCollection.AddScoped<IAuthService, AuthServiceMock>();
            serviceCollection.AddScoped<ITokenService, SqlTokenService>();
            serviceCollection.AddScoped<IdeasService>();

            _serviceProvider = serviceCollection.BuildServiceProvider();

            MapperExtensions.Configure();
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
    }
}
