using System.Text;
using Konscious.Security.Cryptography;

namespace PrototipoERP.Infraestrutura.Criptografia
{
    public static class Argon2EncryptHash
    {
        public static byte[] HashPassword(string password)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                DegreeOfParallelism = 8, // 4 cores
                Iterations = 4,
                MemorySize = 1024 * 1024 // 1 GB
            };

            return argon2.GetBytes(16);
        }
    }
}
