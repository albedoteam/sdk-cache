using AlbedoTeam.Sdk.Cache.Abstractions;

namespace AlbedoTeam.Sdk.Cache.Internals;

public class CacheOptions : ICacheOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Password { get; set; }
    public string InstanceName { get; set; }
}