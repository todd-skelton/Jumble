namespace Jumble
{
    /// <summary>
    /// Interface used to create a custom password hash
    /// </summary>
    public interface IPasswordHash
    {
        int Iterations { get; }
        byte[] Hash { get; }
        byte[] Salt { get; }
    }
}
