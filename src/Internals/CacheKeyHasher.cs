namespace AlbedoTeam.Sdk.Cache.Internals
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal static class CacheKeyHasher
    {
        private static string EncryptWithMd5(string value)
        {
            var encoding = new UTF8Encoding();
            var bytes = encoding.GetBytes(value);

            // encrypt bytes
            var md5 = new MD5CryptoServiceProvider();
            var hashBytes = md5.ComputeHash(bytes);

            // convert the encrypted bytes back to a string (base 16)
            var hashString = hashBytes
                .Aggregate("", (current, hashByte) =>
                    current + Convert.ToString(hashByte, 16).PadLeft(2, '0'));

            return hashString.PadLeft(32, '0');
        }

        private static string EncryptWithSha(string value)
        {
            var encoding = new UTF8Encoding();
            var bytes = encoding.GetBytes(value);

            // encrypt bytes
            var sha = new SHA1CryptoServiceProvider();
            var hashBytes = sha.ComputeHash(bytes);

            // convert the encrypted bytes back to a string (base 16)
            var hashString = hashBytes
                .Aggregate("", (current, hashByte) =>
                    current + Convert.ToString(hashByte, 16).PadLeft(2, '0'));

            return hashString.PadLeft(32, '0');
        }

        public static string EncryptString(string value, CacheKeyHashAlgorithm algorithm = CacheKeyHashAlgorithm.Sha1)
        {
            return algorithm switch
            {
                CacheKeyHashAlgorithm.Md5 => EncryptWithMd5(value),
                CacheKeyHashAlgorithm.Sha1 => EncryptWithSha(value),
                _ => throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null)
            };
        }
    }
}