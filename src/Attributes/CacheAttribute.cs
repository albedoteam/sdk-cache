using System;

namespace AlbedoTeam.Sdk.Cache.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CacheAttribute : Attribute
{
    public CacheAttribute(int expirationInSeconds)
    {
        ExpirationInSeconds = expirationInSeconds;
    }

    public int ExpirationInSeconds { get; }
}