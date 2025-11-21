// Services/PasswordHasher.cs
using System;
using System.Security.Cryptography;
using System.Text;

namespace PROG_POE.Services
{
    public static class PasswordHasher
    {
        // Returns base64-encoded string: salt(16) + hash(32)
        public static string Hash(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[16];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 150_000, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);

            var combined = new byte[16 + 32];
            Array.Copy(salt, 0, combined, 0, 16);
            Array.Copy(hash, 0, combined, 16, 32);

            return Convert.ToBase64String(combined);
        }

        public static bool Verify(string password, string stored)
        {
            var combined = Convert.FromBase64String(stored);
            var salt = new byte[16];
            var hash = new byte[32];

            Array.Copy(combined, 0, salt, 0, 16);
            Array.Copy(combined, 16, hash, 0, 32);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 150_000, HashAlgorithmName.SHA256);
            var computed = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(computed, hash);
        }
    }
}
