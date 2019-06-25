namespace Jumble
{
    /// <summary>
    /// Interface used to implement a hash generator
    /// </summary>
    public interface IHashGenerator
    {
        /// <summary>
        /// Generates a password hash struct from a password string.
        /// </summary>
        /// <param name="password">Password string</param>
        /// <returns>A password hash struct</returns>
        PasswordHash Generate(string password);

        /// <summary>
        /// Generates a password hash struct from a password string, number of iterations, and salt.
        /// </summary>
        /// <param name="password">Password string</param>
        /// <param name="iterations">Number of iterations to hash</param>
        /// <param name="salt">Salt to use</param>
        /// <returns></returns>
        PasswordHash Generate(string password, int iterations, byte[] salt);

        /// <summary>
        /// Validates a password string against a password hash struct
        /// </summary>
        /// <param name="hash">Hash to check against</param>
        /// <param name="password">Password string being validated</param>
        /// <returns>true if the password string matches the hash</returns>
        bool Validate(PasswordHash hash, string password);
    }
}
