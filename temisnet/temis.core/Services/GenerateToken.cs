using System.Security.Cryptography;
using System.Text;

namespace Solutis.Services
{
    public class GenerateToken
    {
        public static string GenerateMD5(string input)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));

            }
            return strBuilder.ToString();
        }
    }
}