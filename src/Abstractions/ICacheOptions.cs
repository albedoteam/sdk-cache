namespace AlbedoTeam.Sdk.Cache.Abstractions;

public interface ICacheOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Password { get; set; }
    string InstanceName { get; set; }
}