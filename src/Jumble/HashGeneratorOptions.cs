namespace Jumble
{
    /// <summary>
    /// Options used for generating password hashs.
    /// </summary>
    public class HashGeneratorOptions
    {
        /// <summary>
        /// Initializes hash generator options with 1000 iterations and a length of 512 bytes.
        /// </summary>
        public HashGeneratorOptions():this(1000, 512)
        {
        }

        /// <summary>
        /// Initializes hash generator options with specified iterations and length.
        /// </summary>
        /// <param name="iterations">Number of iterations to hash the password</param>
        /// <param name="length">Length of the resulting hash in bytes</param>
        public HashGeneratorOptions(int iterations, int length)
        {
            Iterations = iterations;
            Length = length;
        }

        /// <summary>
        /// Number of iterations to hash the password
        /// </summary>
        public int Iterations { get; }

        /// <summary>
        /// Length of the resulting hash in bytes
        /// </summary>
        public int Length { get; }
    }
}
