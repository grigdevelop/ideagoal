using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaGoal.Domain.Core.Entities
{
    public class Idea : IEntity
    {
        public int Id { get; set; }
       
        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
