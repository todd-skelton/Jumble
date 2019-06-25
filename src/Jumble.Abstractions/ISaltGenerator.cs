namespace Jumble
{
    /// <summary>
    /// Interface used to create a custom salt generator
    /// </summary>
    public interface ISaltGenerator
    {
        /// <summary>
        /// Generates a salt
        /// </summary>
        /// <returns></returns>
        byte[] Generate();
    }
}
