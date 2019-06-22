namespace Jumble
{
    /// <summary>
    /// Interface used to create a custom salt generator
    /// </summary>
    public interface ISaltGenerator
    {
        byte[] Generate();
    }
}
