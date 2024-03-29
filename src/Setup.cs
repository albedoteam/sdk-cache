﻿using System;
using System.Net;
using AlbedoTeam.Sdk.Cache.Abstractions;
using AlbedoTeam.Sdk.Cache.Internals;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace AlbedoTeam.Sdk.Cache;

public static class Setup
{
    public static IServiceCollection AddCache(
        this IServiceCollection services,
        Action<ICacheConfigurator> configure)
    {
        if (configure == null)
            throw new ArgumentNullException(nameof(configure));

        services.AddScoped<ICacheConfigurator, CacheConfigurator>();
        var provider = services.BuildServiceProvider();
        var cacheConfiguration = provider.GetService<ICacheConfigurator>();
        configure.Invoke(cacheConfiguration);

        services.AddScoped<ICacheService, CacheService>();

        services.AddDistributedRedisCache(options =>
        {
            options.InstanceName = cacheConfiguration.Options.InstanceName;
            options.ConfigurationOptions = new ConfigurationOptions
            {
                Password = cacheConfiguration.Options.Password,
                EndPoints = { new DnsEndPoint(cacheConfiguration.Options.Host, cacheConfiguration.Options.Port) }
            };
        });

        return services;
    }
}