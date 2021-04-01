namespace AlbedoTeam.Sdk.Cache.Abstractions
{
    using System;

    public interface ICacheConfigurator
    {
        ICacheOptions Options { get; }
        ICacheConfigurator SetOptions(Action<ICacheOptions> configureOptions);
    }
}