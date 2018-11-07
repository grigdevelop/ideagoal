using IdeaGoal.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaGoal.Domain.Core.Data
{
    public class IdeaGoalDbContext : DbContext
    {
        public IdeaGoalDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }
    }
}
