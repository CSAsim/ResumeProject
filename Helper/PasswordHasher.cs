using ResumeProject.Exceptions;

namespace ResumeProject.Helper
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new RestException("Password must not be null");
            }
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
