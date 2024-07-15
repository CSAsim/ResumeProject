using Npgsql;
using ResumeProject.DTOs.Auth;

namespace ResumeProject.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> Register(RegisterDTO register);
        Task<string> Login(LoginDTO login);
        Task<Object> ForgotPassword(ForgotPasswordDTO forgot);
        Task<bool> ResetPassword(ResetPasswordDTO changePassword);

    }
}
