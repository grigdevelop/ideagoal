using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Dto;

namespace IdeaGoal.Domain.Services.Account.Dto
{
    public class UserDto : IEntityDto
    {
        public int Id { get; set; }

        public string Username { get; set; }
    }
}
