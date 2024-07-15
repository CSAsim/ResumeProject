using ResumeProject.DTOs.Auth;
using ResumeProject.Response;

namespace ResumeProject.Services.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse> Register(RegisterDTO register);
        Task<BaseResponse> Login(LoginDTO login);
        Task<BaseResponse> ForgotPassword(ForgotPasswordDTO forgot);
        Task<BaseResponse> ResetPassword(ResetPasswordDTO changePassword);
    }
}
