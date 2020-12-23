using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using temis.api;
using temis.Core.Models;

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