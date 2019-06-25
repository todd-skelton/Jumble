using System.Security.Cryptography;

namespace Jumble
{
    /// <summary>
    /// Standard implementation of <see cref="IHashGenerator"/> used to generate password hashes
    /// </summary>
    public class HashGenerator : IHashGenerator
    {
        private readonly HashGeneratorOptions _options;
        private readonly ISaltGenerator _saltGenerator;

        public HashGenerator() : this(new HashGeneratorOptions(1000, 256))
        {
        }

        public HashGenerator(HashGeneratorOptions options) : this(options, new SaltGenerator())
        {
        }

        public HashGenerator(HashGeneratorOptions options, ISaltGenerator saltGenerator)
        {
            _options = options;
            _saltGenerator = saltGenerator;
        }

        /// <summary>
        /// Generates a password hash using the options set by the application
        /// </summary>
        /// <param name="password">The password to be encypted</param>
        /// <returns>A password hash</returns>
        public PasswordHash Generate(string password)
        {
            var salt = _saltGenerator.Generate();
            return Generate(password, _options.Iterations, salt);
        }

        /// <summary>
        /// Generates a password hash when the salt and iterations are known.
        /// </summary>
        /// <param name="password">The password to be encrypted</param>
        /// <param name="iterations">Number of iterations the encryption algorithm is run</param>
        /// <param name="salt">The salt used to create the hash</param>
        /// <returns>A password hash</returns>
        public PasswordHash Generate(string password, int iterations, byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return new PasswordHash(_options.Iterations, salt, rfc2898DeriveBytes.GetBytes(_options.Length));
            }
        }

        /// <summary>
        /// Validates a value against a hash.
        /// </summary>
        /// <param name="password">The password being validated</param>
        /// <param name="hash">The hash used to validate</param>
        /// <returns></returns>
        public bool Validate(PasswordHash hash, string password)
        {
            var valueHash = Generate(password, hash.Iterations, hash.Salt);

            return hash == valueHash;
        }
    }
}
