using ResumeProject.DTOs.Auth;
using ResumeProject.Response;
using ResumeProject.Services.Interfaces;

namespace ResumeProject.Services.Implements
{
    public class AuthService : IAuthService
    {
        public Task<BaseResponse> Register(RegisterDTO register)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Login(LoginDTO login)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> ForgotPassword(ForgotPasswordDTO forgot)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> ResetPassword(ResetPasswordDTO changePassword)
        {
            throw new NotImplementedException();
        }
    }
}
