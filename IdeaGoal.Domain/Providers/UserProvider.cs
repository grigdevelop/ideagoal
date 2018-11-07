using IdeaGoal.Domain.Services.Ideas.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaGoal.Domain.Providers
{
    public class UserProvider
    {
        private readonly int _userId;

        public UserProvider(int userId)
        {
            _userId = userId;
        }

        public void CreateIdea(CreateIdeaDto input)
        {

        }

        public void UpdateIdea(UpdateIdeaDto input)
        {

        }

        public void DeleteIdea(int ideaId)
        {

        }
    }
}
