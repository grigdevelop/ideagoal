using IdeaGoal.Domain.Services.Dto;

namespace IdeaGoal.Domain.Services.Components.Dto
{
    public class ComponentDtoBase : IEntityDto
    {
        public int IdeaId { get; set; }
    }

    public class ComponentDto : ComponentDtoBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class CreateComponentDto : ComponentDtoBase
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class CreateComponentResultDto : CreateComponentDto
    {
        public int Id { get; set; }

        public CreateComponentResultDto(ComponentDto dto)
        {
            this.Id = dto.Id;
            this.Title = dto.Title;
            this.Description = dto.Description;
            this.IdeaId = dto.IdeaId;
        }
    }
}
