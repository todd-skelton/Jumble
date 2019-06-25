using System;

namespace Jumble
{
    /// <summary>
    /// Standard password hash implementation
    /// </summary>
    public struct PasswordHash : IEquatable<PasswordHash>
    {
        /// <summary>
        /// Initializes a new password hash.
        /// </summary>
        /// <param name="iterations">Number of iterations to run the hashing algorithm</param>
        /// <param name="salt">Salt used to create the hash value</param>
        /// <param name="hash">Hash value</param>
        public PasswordHash(int iterations, byte[] salt, byte[] hash)
        {
            Iterations = iterations;
            Salt = salt;
            Hash = hash;
        }

        /// <summary>
        /// Number of iterations to run the hashing algorithm
        /// </summary>
        public int Iterations { get; }

        /// <summary>
        /// Hash value
        /// </summary>
        public byte[] Hash { get; }

        /// <summary>
        /// Salt used to create the hash value
        /// </summary>
        public byte[] Salt { get; }

        /// <summary>
        /// Compares this value object to another.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns></returns>
        public override bool Equals(object obj) => obj is PasswordHash other && Equals(other);

        /// <summary>
        /// Use this method to convert the hash into a string that can be stored in a database.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Iterations}${Convert.ToBase64String(Salt)}${Convert.ToBase64String(Hash)}";

        /// <summary>
        /// Used to parse password hash strings using <see cref="ToString()"/> back into a <see cref="PasswordHash"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PasswordHash Parse(string value)
        {
            string[] split = value.Split(new[] { '$' }, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length != 3 || !int.TryParse(split[0], out int iterations))
                throw new ArgumentException("Value must be a valid combined hash.", nameof(value));

            byte[] salt = Convert.FromBase64String(split[1]);

            byte[] hash = Convert.FromBase64String(split[2]);

            return new PasswordHash(iterations, salt, hash);
        }

        /// <summary>
        /// Gets the hash code for the value object.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <summary>
        /// Checks if two hashes are equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(PasswordHash other) => ByteCompare(Hash, other.Hash);

        /// <summary>
        /// The equality operator to compare two hashes.
        /// </summary>
        /// <param name="a">The first value object.</param>
        /// <param name="b">The second value object.</param>
        /// <returns>Returns true if both are null or the result of <see cref="Equals(object)"/>.</returns>
        public static bool operator ==(PasswordHash a, PasswordHash b) => a.Equals(b);

        /// <summary>
        /// The inequality operator to compare two hashes.
        /// </summary>
        /// <param name="a">The first value object.</param>
        /// <param name="b">The second value object.</param>
        /// <returns>Returns false if both objects are null or the inverse of <see cref="Equals(object)"/>.</returns>
        public static bool operator !=(PasswordHash a, PasswordHash b) => !(a == b);

        private static bool ByteCompare(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }
    }
}
