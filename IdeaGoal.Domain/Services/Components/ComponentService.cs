using IdeaGoal.Domain.Core.Data.Repo;
using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Account;
using IdeaGoal.Domain.Services.Components.Dto;
using IdeaGoal.Domain.Services.Ideas;
using IdeaGoal.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaGoal.Domain.Services.Components
{
    public class ComponentService : ServiceBase, IComponentService
    {
        private readonly IIdeaService _ideaService;
        private readonly IRepository<Component> _componentRepository;

        public ComponentService(IAccountService accountService, IIdeaService ideaService, IRepository<Component> componentRepository)
            :base(accountService)
        {
            this._ideaService = ideaService;
            this._componentRepository = componentRepository;
        }

        public CreateComponentResultDto CreateComponent(CreateComponentDto input)
        {
            UserAccess();
            ValidateComponentIdea(input);

            var component = new Component { IdeaId = input.IdeaId, Title = input.Title, Description = input.Description };
            component = _componentRepository.Insert(component);
            return new CreateComponentResultDto(component.ToEntityDto<ComponentDto>());
        }


        private void ValidateComponentIdea(ComponentDtoBase dto)
        {
            
            if (dto.IdeaId == 0) throw new Exception("IdeaId can't be zero.");

            var idea = _ideaService.GetById(dto.IdeaId);
            if (idea == null) throw new Exception($"Idea with id '{dto.IdeaId}' not found.");
        }
    }
}
