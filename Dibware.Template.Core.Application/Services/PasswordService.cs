using Dibware.Template.Core.Domain.Contracts.Services;
using System;
using System.Security.Cryptography;

namespace Dibware.Template.Core.Application.Services
{
    public class PasswordService : IPasswordService
    {
        #region Reference

        // REf:
        //  Salted Password Hashing - Doing it Right
        // https://crackstation.net/hashing-security.htm
        //

        #endregion

        #region Declarations

        // The following constants may be changed without breaking existing hashes.
        //public const int SALT_BYTE_SIZE = 24;
        //public const int HASH_BYTE_SIZE = 24;
        //public const int PBKDF2_ITERATIONS = 1000;

        private readonly char[] DELIMITER = { ':' };
        private const int ITERATION_INDEX = 0;
        private const int SALT_INDEX = 1;
        private const int PBKDF2_INDEX = 2;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordService"/> class.
        /// </summary>
        /// <param name="hashByteSize">
        /// Size in bytes of the hash. May be changed without breaking existing hashes.
        /// </param>
        /// <param name="saltByteSize">
        /// Size in bytes of the salt. May be changed without breaking existing hashes.
        /// </param>
        /// <param name="pbkdf2Iterations">
        /// The number of PBKDF2 iterations to use. May be changed 
        /// without breaking existing hashes.
        /// </param>
        public PasswordService(Int32 hashByteSize, Int32 saltByteSize,
            Int32 pbkdf2Iterations)
        {
            HashByteSize = hashByteSize;
            SaltByteSize = saltByteSize;
            PBKDF2Iterations = pbkdf2Iterations;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the size in bytes of the hash.
        /// </summary>
        /// <value>
        /// The size of the hash byte.
        /// </value>
        private Int32 HashByteSize { get; set; }

        /// <summary>
        /// Gets or sets the size in bytes of the salt.
        /// </summary>
        /// <value>
        /// The size of the salt byte.
        /// </value>
        private Int32 SaltByteSize { get; set; }

        /// <summary>
        /// Gets or sets the PBKDF2 (Password-Based Key Derivation Function 2) iterations.
        /// </summary>
        /// <value>
        /// The PBKDF2 iterations.
        /// </value>
        /// <ref>
        /// http://en.wikipedia.org/wiki/PBKDF2
        /// </ref>
        private Int32 PBKDF2Iterations { get; set; }

        #endregion

        /// <summary>
        /// Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        public String CreateHash(String password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2Iterations, HashByteSize);
            return PBKDF2Iterations +
                DELIMITER.ToString() +
                Convert.ToBase64String(salt) +
                DELIMITER.ToString() +
                Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public Boolean ValidatePassword(String password, String correctHash)
        {
            // Extract the parameters from the hash
            String[] split = correctHash.Split(DELIMITER);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);
            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);

            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static Boolean SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        /// <summary>
        /// Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(String password, byte[] salt, Int32 iterations, Int32 outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}