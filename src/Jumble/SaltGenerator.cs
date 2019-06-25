using System.Security.Cryptography;

namespace Jumble
{
    /// <summary>
    /// Standard implementation to generate salts for use in a <see cref="HashGenerator"/>
    /// </summary>
    public class SaltGenerator : ISaltGenerator
    {
        private readonly SaltGeneratorOptions _options;

        public SaltGenerator() : this(new SaltGeneratorOptions(32))
        {
        }

        public SaltGenerator(SaltGeneratorOptions options)
        {
            _options = options;
        }

        public byte[] Generate()
        {
            var salt = new byte[_options.Length];
            using (var provider = new RNGCryptoServiceProvider())
                provider.GetNonZeroBytes(salt);

            return salt;
        }
    }
}
