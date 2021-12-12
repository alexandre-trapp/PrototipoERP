using System.Text;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;

namespace PrototipoERP.Infraestrutura.Criptografia
{
    public static class Argon2EncryptHash
    {
        public static byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8, // 4 cores
                Iterations = 4,
                MemorySize = 1024 * 1024 // 1 GB
            };

            return argon2.GetBytes(16);
        }

        public static byte[] CreateSalt()
        {
            using var generator = RandomNumberGenerator.Create();

            var salt = new byte[16];
            generator.GetBytes(salt);

            return salt;
        }
    }
}
