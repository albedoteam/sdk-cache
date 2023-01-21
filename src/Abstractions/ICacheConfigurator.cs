using System;

namespace AlbedoTeam.Sdk.Cache.Abstractions;

public interface ICacheConfigurator
{
    ICacheOptions Options { get; }
    ICacheConfigurator SetOptions(Action<ICacheOptions> configureOptions);
}