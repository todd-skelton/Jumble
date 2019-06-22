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

        public HashGenerator(HashGeneratorOptions options, ISaltGenerator saltGenerator)
        {
            _options = options;
            _saltGenerator = saltGenerator;
        }

        /// <summary>
        /// Generates a password hash using the options set by the application
        /// </summary>
        /// <param name="value">The password to be encypted</param>
        /// <returns>A password hash</returns>
        public IPasswordHash Generate(string value)
        {
            var salt = _saltGenerator.Generate();
            return Generate(_options.Iterations, salt, value);
        }

        /// <summary>
        /// Generates a password hash when the salt and iterations are known. Use this method for validating passwords against hashes.
        /// </summary>
        /// <param name="iterations">Number of iterations the encryption algorithm is run</param>
        /// <param name="salt">The salt used to create the hash</param>
        /// <param name="value">The password to be encrypted</param>
        /// <returns>A password hash</returns>
        public IPasswordHash Generate(int iterations, byte[] salt, string value)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(value, salt, iterations))
            {
                return new PasswordHash(_options.Iterations, salt, rfc2898DeriveBytes.GetBytes(_options.Length));
            }
        }
    }
}
