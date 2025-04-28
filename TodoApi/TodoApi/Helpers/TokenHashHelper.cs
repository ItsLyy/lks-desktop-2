using Microsoft.AspNetCore.Identity;

namespace TodoApi.Helpers
{
    public class TokenHashHelper
    {
        private readonly PasswordHasher<object> _hasher = new PasswordHasher<object>();

        public string HashToken(string token)
        {
            return _hasher.HashPassword(null, token);
        }

        public bool VerifyToken(string token, string hashedToken)
        {
            var result = _hasher.VerifyHashedPassword(null, hashedToken, token);
            return result == PasswordVerificationResult.Success;
        }
    }
}
