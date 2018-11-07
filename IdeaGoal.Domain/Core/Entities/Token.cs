using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaGoal.Domain.Core.Entities
{
    public class UserToken
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public int UserId { get; set; }
    }
}
