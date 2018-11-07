namespace IdeaGoal.Domain.Services.Account.Dto
{
    public class RegisterDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }
    }

    public class RegisterResultDto : LoginResultDto
    {

    }
}
