using IdeaGoal.Domain.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaGoal.Domain.UnitTests.Core
{
    public class TestBaseDb : TestBase
    {
        protected DbContext UsingContext()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
            return new IdeaGoalDbContext(builder.Options);
        }
    }
}
