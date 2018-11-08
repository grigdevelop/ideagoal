using FluentAssertions;
using IdeaGoal.Domain.Core.Data.Repo;
using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Ideas;
using IdeaGoal.Domain.Services.Ideas.Dto;
using IdeaGoal.Domain.UnitTests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using IdeaGoal.Domain.Core.Data;
using IdeaGoal.Domain.UnitTests.Utilities;

namespace IdeaGoal.Domain.UnitTests.Services
{
    [TestClass]
    public class IdeaServiceTests : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            DbHelper.CleanDb(GetService<IdeaGoalDbContext>());
        }

        [TestMethod]
        public void Should_Create_Idea()
        {
            AuthorizeUser();

            var service = GetService<IIdeaService>();
            var createIdeaInput = new CreateIdeaDto { Description = "Lorem ipsum", Title = "Go to school" };
            var result = service.CreateIdea(createIdeaInput);

            var repo = GetService<IRepository<Idea>>();
            var dbIdea = repo.Table.FirstOrDefault(x => x.Id == result.Id);

            dbIdea.Should().NotBeNull();
            dbIdea.Description.Should().BeEquivalentTo(createIdeaInput.Description);
            dbIdea.Title.Should().BeEquivalentTo(createIdeaInput.Title);
        }

        [TestMethod]
        public void Should_Update_Idea()
        {
            AuthorizeUser();

            var service = GetService<IIdeaService>();
            var existingIdea = service.CreateIdea(new CreateIdeaDto { Description = "Lorem", Title = "Ipsum" });
            var updateIdeaInput = new UpdateIdeaDto { Id = existingIdea.Id, Description = "Lorem 2", Title = "Ipsum 1" };
            var result = service.UpdateIdea(updateIdeaInput);

            result.Should().NotBeNull();
            result.Description.Should().BeEquivalentTo(updateIdeaInput.Description);
            result.Title.Should().BeEquivalentTo(updateIdeaInput.Title);
        }

        [TestMethod]
        public void Should_Delete_Idea()
        {
            AuthorizeUser();

            var service = GetService<IIdeaService>();
            var existingIdea = service.CreateIdea(new CreateIdeaDto { Description = "Lorem", Title = "Ipsum" });
            service.DeleteIdea(new DeleteIdeaDto{Id = existingIdea.Id});

            var repo = GetService<IRepository<Idea>>();
            var idea = repo.Table.FirstOrDefault(x => x.Id == existingIdea.Id);
            idea.Should().BeNull();
        }

        [TestMethod]
        public void Should_Get_User_Ideas()
        {
            var currentUser = AuthorizeUser();

            var repo = GetService<IRepository<Idea>>();
            var idea1 = repo.Insert(new Idea{Title = "Lorem", Description = "Ipsum", UserId = currentUser.Id});
            var idea2 = repo.Insert(new Idea{Title = "Lorem 2", Description = "Ipsum 2", UserId = currentUser.Id });

            var service = GetService<IIdeaService>();
            var ideas = service.GetUserIdeas();
            ideas.Count.Should().Be(2);
            ideas[0].Description.Should().Be(idea1.Description);
            ideas[1].Title.Should().Be(idea2.Title);

            // should be correct after delete
            service.DeleteIdea(new  DeleteIdeaDto{Id = idea2.Id});

            ideas = service.GetUserIdeas();
            ideas.Count.Should().Be(1);
            ideas[0].Title.Should().Be(idea1.Title);
        }
    }
}
