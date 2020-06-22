using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CashbackManaging.Utility
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AuthOptions
    {
        public const string ISSUER = "CashbackManaging"; // издатель токена

        public const string AUDIENCE = "CashbackManagingClient"; // потребитель токена

        private const string KEY = "e12ff12a-3392-495c-8fa6-ef649247f5df";   // ключ для шифрации

        public const int LIFETIME = 120;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}