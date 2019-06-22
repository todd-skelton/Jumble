namespace Jumble
{
    /// <summary>
    /// Interface used to implement a custom hash generator
    /// </summary>
    public interface IHashGenerator
    {
        IPasswordHash Generate(string value);
        IPasswordHash Generate(int iterations, byte[] salt, string value);
    }
}
