namespace AlbedoTeam.Sdk.Cache.Abstractions
{
    public interface ICacheService
    {
        bool TryGet<TValue>(string key, out TValue value);
        bool TryGet<TKey, TValue>(TKey key, out TValue value);
        void Set<TValue>(string key, TValue value, int expirationInSeconds);
        void Set<TKey, TValue>(TKey key, TValue value, int expirationInSeconds);
    }
}