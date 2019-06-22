namespace Jumble
{
    /// <summary>
    /// Options used for generating password hashs.
    /// </summary>
    public class HashGeneratorOptions
    {
        public HashGeneratorOptions(int iterations, int length)
        {
            Iterations = iterations;
            Length = length;
        }

        public int Iterations { get; }
        public int Length { get; }
    }
}
