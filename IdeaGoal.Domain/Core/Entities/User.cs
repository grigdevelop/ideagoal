using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaGoal.Domain.Core.Entities
{
    //[Table("[dbo].[Users]")]
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}
