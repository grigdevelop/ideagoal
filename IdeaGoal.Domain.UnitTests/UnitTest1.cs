using IdeaGoal.Domain.Core.Data;
using IdeaGoal.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IdeaGoal.Domain.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
            using(IdeaGoalDbContext db = new IdeaGoalDbContext(builder.Options))
            {
                db.Database.ExecuteSqlCommand(@"CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Username] NVARCHAR(255) NOT NULL
)");

                db.Users.Add(new User { Username = "grigdevelop" });
                db.SaveChanges();

                var users = db.Users.ToList();
            }
        }
    }
}
