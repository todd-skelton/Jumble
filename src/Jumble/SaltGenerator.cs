using System.Security.Cryptography;

namespace Jumble
{
    /// <summary>
    /// Standard implementation to generate salts for use in a <see cref="HashGenerator"/>
    /// </summary>
    public class SaltGenerator : ISaltGenerator
    {
        private readonly SaltGeneratorOptions _options;

        /// <summary>
        /// Initializes a new salt generator with default options.
        /// </summary>
        public SaltGenerator() : this(new SaltGeneratorOptions())
        {
        }

        /// <summary>
        /// Initializes a new salt generator with specified options.
        /// </summary>
        /// <param name="options">Salt generator options to use.</param>
        public SaltGenerator(SaltGeneratorOptions options)
        {
            _options = options;
        }

        /// <summary>
        /// Generates a new salt.
        /// </summary>
        /// <returns>A new salt as a byte array.</returns>
        public byte[] Generate()
        {
            var salt = new byte[_options.Length];
            using (var provider = new RNGCryptoServiceProvider())
                provider.GetNonZeroBytes(salt);

            return salt;
        }
    }
}
