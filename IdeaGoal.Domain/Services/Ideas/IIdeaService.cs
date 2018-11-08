using System.Collections.Generic;
using IdeaGoal.Domain.Services.Ideas.Dto;

namespace IdeaGoal.Domain.Services.Ideas
{
    public interface IIdeaService
    {
        SaveIdeaResultDto CreateIdea(CreateIdeaDto input);

        SaveIdeaResultDto UpdateIdea(UpdateIdeaDto input);

        void DeleteIdea(DeleteIdeaDto input);

        List<IdeaDto> GetUserIdeas();

        IdeaDto GetById(int id);
    }
}
