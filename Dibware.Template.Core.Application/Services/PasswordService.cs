using Dibware.Template.Core.Domain.Contracts.Services;
using System;
using System.Security.Cryptography;
using System.Text;

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

        private readonly char[] DELIMITER = { ':' };
        private const Int32 DELIMITER_INDEX = 0;
        private const Int32 ITERATION_INDEX = 0;
        private const Int32 SALT_INDEX = 1;
        private const Int32 PBKDF2_INDEX = 2;
        private static Random _random = new Random((int)DateTime.Now.Ticks); //thanks to McAden

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordService" /> class.
        /// </summary>
        /// <param name="hashByteSize">Size in Bytes of the hash. May be changed without breaking existing hashes.</param>
        /// <param name="saltByteSize">Size in Bytes of the salt. May be changed without breaking existing hashes.</param>
        /// <param name="pbkdf2Iterations">The number of PBKDF2 iterations to use. May be changed
        /// without breaking existing hashes.</param>
        /// <param name="confirmationTokenLength">Length in characters of the confirmation token.</param>
        public PasswordService(Int32 hashByteSize, Int32 saltByteSize,
            Int32 pbkdf2Iterations, Int32 confirmationTokenLength,
            Int32 minRequiredPasswordLength, Int32 minRequiredNonAlphanumericCharacters,
            String passwordStrengthRegularExpression)
        {
            HashByteSize = hashByteSize;
            SaltByteSize = saltByteSize;
            PBKDF2Iterations = pbkdf2Iterations;
            ConfirmationTokenLength = confirmationTokenLength;
            MinRequiredPasswordLength = minRequiredPasswordLength;
            MinRequiredNonAlphanumericCharacters = minRequiredNonAlphanumericCharacters;
            PasswordStrengthRegularExpression = passwordStrengthRegularExpression;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the length of the confirmation token.
        /// </summary>
        /// <value>
        /// The length of the confirmation token.
        /// </value>
        private Int32 ConfirmationTokenLength { get; set; }

        /// <summary>
        /// Gets or sets the size in Bytes of the hash.
        /// </summary>
        /// <value>
        /// The size of the hash Byte.
        /// </value>
        private Int32 HashByteSize { get; set; }

        /// <summary>
        /// Gets the minimum password length
        /// </summary>
        public Int32 MinRequiredPasswordLength { get; private set; }

        /// <summary>
        /// Gets the minimum required non alphanumeric characters
        /// </summary>
        public Int32 MinRequiredNonAlphanumericCharacters { get; private set; }

        /// <summary>
        /// Gets the regular expression for the password strength
        /// </summary>
        public String PasswordStrengthRegularExpression { get; private set; }

        /// <summary>
        /// Gets or sets the size in Bytes of the salt.
        /// </summary>
        /// <value>
        /// The size of the salt Byte.
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
            var delimiter = DELIMITER[DELIMITER_INDEX].ToString();

            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            Byte[] salt = new Byte[SaltByteSize];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            Byte[] hash = PBKDF2(password, salt, PBKDF2Iterations, HashByteSize);
            return PBKDF2Iterations +
                delimiter +
                Convert.ToBase64String(salt) +
                delimiter +
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
            Int32 iterations = Int32.Parse(split[ITERATION_INDEX]);
            Byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            Byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);
            Byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);

            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Creates the confirmation token.
        /// </summary>
        /// <returns></returns>
        public String CreateConfirmationToken()
        {
            return GetRandomString(ConfirmationTokenLength);
        }

        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <ref>
        /// http://stackoverflow.com/questions/1122483/random-string-generator-returning-same-string
        /// </ref>
        /// <returns></returns>
        private String GetRandomString(Int32 size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (Int32 i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }


        /// <summary>
        /// Compares two Byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first Byte array.</param>
        /// <param name="b">The second Byte array.</param>
        /// <returns>True if both Byte arrays are equal. False otherwise.</returns>
        private static Boolean SlowEquals(Byte[] a, Byte[] b)
        {
            UInt32 diff = (UInt32)a.Length ^ (UInt32)b.Length;
            for (Int32 i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (UInt32)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        /// <summary>
        /// Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in Bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static Byte[] PBKDF2(String password, Byte[] salt, Int32 iterations, Int32 outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}