namespace AlbedoTeam.Sdk.Cache.Internals
{
    using Abstractions;

    public class CacheOptions : ICacheOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string InstanceName { get; set; }
    }
}