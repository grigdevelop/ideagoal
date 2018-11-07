namespace IdeaGoal.Domain.Services.Utilities
{
    public interface ICacheService
    {
        T Get<T>(string key);

        bool TryGetValue<T>(string key, out T item);

        void Set<T>(string key, T item);

        void Remove(string key);
    }
}
