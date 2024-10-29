namespace APIMarketList.Domain.Interface.Services
{
    public interface ICachingService
    {
        Task <string> GetAsync(string key);
        Task SetAsync(string key, string value);
        Task<T?> GetOrCreate<T>(string key, Func<Task<T>> function);
    }
}
