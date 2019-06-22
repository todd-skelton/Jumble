using System;

namespace Jumble
{
    /// <summary>
    /// Standard password hash implementation
    /// </summary>
    public class PasswordHash : IPasswordHash
    {
        public PasswordHash(int iterations, byte[] salt, byte[] hash)
        {
            Iterations = iterations;
            Salt = salt;
            Hash = hash;
        }

        public int Iterations { get; private set; }

        public byte[] Hash { get; private set; }

        public byte[] Salt { get; private set; }

        /// <summary>
        /// Compares this value object to another.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is IPasswordHash other)
            {
                return other == this;
            }
            return false;
        }

        /// <summary>
        /// Use this method to convert the hash into a string that can be stored in a database.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"${Iterations}${Convert.ToBase64String(Salt)}${Convert.ToBase64String(Hash)}";
        }

        /// <summary>
        /// Used to parse password hash strings using <see cref="ToString()"/> back into a <see cref="PasswordHash"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PasswordHash Parse(string value)
        {
            string[] split = value.Split(new[] { '$' }, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length != 3 || !Int32.TryParse(split[0], out int iterations))
                throw new ArgumentException("must be a valid combined hash", "combinedHash");

            byte[] salt = Convert.FromBase64String(split[1]);

            byte[] hash = Convert.FromBase64String(split[2]);

            return new PasswordHash(iterations, salt, hash);
        }

        /// <summary>
        /// Gets the hash code for the value object.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// The equality operator to compare two value objects.
        /// </summary>
        /// <param name="a">The first value object.</param>
        /// <param name="b">The second value object.</param>
        /// <returns>Returns true if both are null or the result of <see cref="Equals(object)"/>.</returns>
        public static bool operator ==(PasswordHash a, IPasswordHash b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        /// <summary>
        /// The inequality operator to compare two value objects.
        /// </summary>
        /// <param name="a">The first value object.</param>
        /// <param name="b">The second value object.</param>
        /// <returns>Returns false if both objects are null or the inverse of <see cref="Equals(object)"/>.</returns>
        public static bool operator !=(PasswordHash a, IPasswordHash b)
        {
            return !(a == b);
        }
    }
}
