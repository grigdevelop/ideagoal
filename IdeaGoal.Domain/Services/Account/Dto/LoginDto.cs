namespace IdeaGoal.Domain.Services.Account.Dto
{
    public class LoginDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public LoginDto()
        {
            
        }

        public LoginDto(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }

    public class LoginResultDto
    {
        public string Token { get; set; }
    }
}
