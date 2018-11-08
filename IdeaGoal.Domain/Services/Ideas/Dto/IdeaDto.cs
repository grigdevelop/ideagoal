using System.ComponentModel.DataAnnotations;
using IdeaGoal.Domain.Services.Dto;

namespace IdeaGoal.Domain.Services.Ideas.Dto
{
    public class IdeaDto : IEntityDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class CreateIdeaDto
    {       
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class SaveIdeaResultDto : IdeaDto
    {
        public SaveIdeaResultDto(IdeaDto idea)
        {
            this.Id = idea.Id;
            this.Title = idea.Title;
            this.Description = idea.Description;
        }
    }

    public class UpdateIdeaDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }
    }

    public class DeleteIdeaDto
    {
        public int Id { get; set; }
    }
}
