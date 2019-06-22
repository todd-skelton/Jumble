namespace Jumble
{
    /// <summary>
    /// Interface used to implement a custom hash generator
    /// </summary>
    public interface IHashGenerator
    {
        PasswordHash Generate(string password);
        PasswordHash Generate(string password, int iterations, byte[] salt);
        bool Validate(PasswordHash hash, string password);
    }
}
