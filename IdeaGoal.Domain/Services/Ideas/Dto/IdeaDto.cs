using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaGoal.Domain.Services.Ideas.Dto
{
    public class IdeaDto
    {
    }

    public class CreateIdeaDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class UpdateIdeaDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }
    }
}
