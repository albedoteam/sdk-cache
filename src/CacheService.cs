using System;
using System.Text.Json;
using AlbedoTeam.Sdk.Cache.Abstractions;
using AlbedoTeam.Sdk.Cache.Internals;
using Microsoft.Extensions.Caching.Distributed;

namespace AlbedoTeam.Sdk.Cache;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public bool TryGet<TValue>(string key, out TValue value)
    {
        var serialized = _cache.GetString(key);
        if (serialized != null)
        {
            value = JsonSerializer.Deserialize<TValue>(serialized);
            return true;
        }

        value = default;
        return false;
    }

    public bool TryGet<TKey, TValue>(TKey key, out TValue value)
    {
        var serializedKey = SerializeKey(key);
        var getted = TryGet(serializedKey, out value);
        return getted;
    }

    public void Set<TValue>(string key, TValue value, int expirationInSeconds)
    {
        var serialized = JsonSerializer.Serialize(value);

        var opcoesCache = new DistributedCacheEntryOptions();
        opcoesCache.SetAbsoluteExpiration(TimeSpan.FromSeconds(expirationInSeconds));

        _cache.SetString(key, serialized, opcoesCache);
    }

    public void Set<TKey, TValue>(TKey key, TValue value, int expirationInSeconds)
    {
        var serializedKey = SerializeKey(key);
        Set(serializedKey, value, expirationInSeconds);
    }

    private static string SerializeKey<TKey>(TKey key)
    {
        var type = key.GetType().Namespace;
        var serialized = $"{type}.{JsonSerializer.Serialize(key)}";

        return CacheKeyHasher.EncryptString(serialized);
    }
}