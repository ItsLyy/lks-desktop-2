using Microsoft.AspNetCore.Identity;

namespace TodoApi.Helpers
{
    public class PasswordHashHelper
    {
        private readonly PasswordHasher<object> _hasher = new PasswordHasher<object>();

        public string PasswordHash(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public bool VerifyPasswordHash(string hashedPassword, string password)
        {
            var result = _hasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
