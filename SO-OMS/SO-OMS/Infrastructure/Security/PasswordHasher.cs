using System;
using System.Linq;
using System.Security.Cryptography;

namespace SO_OMS.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        public string Hash(string password)
        {
            var salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);
            var hashBytes = new byte[SaltSize + HashSize];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public bool Verify(string password, string storedHash)
        {
            var hashBytes = Convert.FromBase64String(storedHash);
            if (hashBytes.Length != SaltSize + HashSize) return false;

            var salt = new byte[SaltSize];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);

            var stored = new byte[HashSize];
            Buffer.BlockCopy(hashBytes, SaltSize, stored, 0, HashSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var computed = pbkdf2.GetBytes(HashSize);

            return stored.SequenceEqual(computed);
        }
    }
}
