using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaGoal.Domain.Core.Data.Repo;
using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Account;
using IdeaGoal.Domain.Services.Ideas.Dto;
using IdeaGoal.Domain.Utilities;
using IdeaGoal.Domain.Utilities.Exceptions;

namespace IdeaGoal.Domain.Services.Ideas
{
    public class IdeasService : ServiceBase, IIdeaService
    {
        private readonly IRepository<Idea> _ideaRepository;

        public IdeasService(
            IAccountService accountService,
            IRepository<Idea> ideaRepository)
        : base(accountService)
        {
            _ideaRepository = ideaRepository;
        }

        public SaveIdeaResultDto CreateIdea(CreateIdeaDto input)
        {
            UserAccess();

            //TODO: Validation
            var idea = new Idea
            {
                UserId = CurrentUser.Id,
                Description = input.Description,
                Title = input.Title
            };
            idea = _ideaRepository.Insert(idea);
            return new SaveIdeaResultDto(idea.ToEntityDto<IdeaDto>());
        }

        public SaveIdeaResultDto UpdateIdea(UpdateIdeaDto input)
        {
            UserAccess();

            _ideaRepository.UpdateRaw("Ideas", $"Id = {input.Id}", new Dictionary<string, object>()
            {
                {nameof(input.Description), input.Description },
                {nameof(input.Title), input.Title },
            });                        
            return new SaveIdeaResultDto(GetById(input.Id));
        }

        public void DeleteIdea(DeleteIdeaDto input)
        {
            UserAccess();

            _ideaRepository.Delete(GetEntityById(input.Id));
        }

        public List<IdeaDto> GetUserIdeas()
        {
            UserAccess();

            return _ideaRepository.Table.Select(x => x.ToEntityDto<IdeaDto>()).ToList();
        }

        public IdeaDto GetById(int id)
        {
            return GetEntityById(id).ToEntityDto<IdeaDto>();
        }

        private Idea GetEntityById(int id)
        {
            return _ideaRepository.Table.FirstOrDefault(x => x.Id == id);
        }
    }
}
