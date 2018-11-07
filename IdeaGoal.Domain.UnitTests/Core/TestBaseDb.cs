using IdeaGoal.Domain.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace IdeaGoal.Domain.UnitTests.Core
{
    public class TestBaseDb : TestBase
    {        
        protected IdeaGoalDbContext UsingContext()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=IdeaGoal.Database;Integrated Security=True;Pooling=False;Connect Timeout=30");
            return new IdeaGoalDbContext(builder.Options);
        }
    }
}
