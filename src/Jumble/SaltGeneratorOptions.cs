namespace Jumble
{
    /// <summary>
    /// Options used to initialize the <see cref="SaltGenerator"/>
    /// </summary>
    public class SaltGeneratorOptions
    {
        public SaltGeneratorOptions(int length)
        {
            Length = length;
        }

        public int Length { get; }
    }
}
