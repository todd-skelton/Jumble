namespace Jumble
{
    /// <summary>
    /// Options used to initialize the <see cref="SaltGenerator"/>
    /// </summary>
    public class SaltGeneratorOptions
    {
        /// <summary>
        /// Initializes salt generator options with a length of 32 bytes.
        /// </summary>
        public SaltGeneratorOptions() : this(32)
        {
        }

        /// <summary>
        /// Initializes salt generator options with a specified length.
        /// </summary>
        /// <param name="length">Length of salt to generate in bytes.</param>
        public SaltGeneratorOptions(int length)
        {
            Length = length;
        }

        /// <summary>
        /// Length of salt to generate in bytes.
        /// </summary>
        public int Length { get; }
    }
}
