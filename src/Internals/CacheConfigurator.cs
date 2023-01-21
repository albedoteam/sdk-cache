using System;
using AlbedoTeam.Sdk.Cache.Abstractions;

namespace AlbedoTeam.Sdk.Cache.Internals;

internal class CacheConfigurator : ICacheConfigurator
{
    public ICacheOptions Options { get; private set; }

    public ICacheConfigurator SetOptions(Action<ICacheOptions> configureOptions)
    {
        ICacheOptions options = new CacheOptions();
        configureOptions.Invoke(options);

        if (string.IsNullOrWhiteSpace(options.Host))
            throw new InvalidOperationException("Can not setup the cache without a valid Host");

        if (string.IsNullOrWhiteSpace(options.Password))
            throw new InvalidOperationException("Can not setup the cache without a valid Password");

        if (string.IsNullOrWhiteSpace(options.InstanceName))
            throw new InvalidOperationException("Can not setup the cache without a valid Instance Name");

        Options = options;
        return this;
    }
}