namespace IdeaGoal.Domain.Services.Security
{
    public interface IEncryptService
    {
        string Encrypt(string text, string key);

        string Decrypt(string text, string key);
    }
}
