using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaGoal.Domain.Core.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}
