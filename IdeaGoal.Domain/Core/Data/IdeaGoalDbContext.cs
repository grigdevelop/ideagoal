using IdeaGoal.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Idea> Ideas { get; set; }

        public DbSet<Component> Components { get; set; }
    }
}
