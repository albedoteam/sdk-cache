namespace AlbedoTeam.Sdk.Cache.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CacheAttribute : Attribute
    {
        public CacheAttribute(int expirationInSeconds)
        {
            ExpirationInSeconds = expirationInSeconds;
        }

        public int ExpirationInSeconds { get; }
    }
}