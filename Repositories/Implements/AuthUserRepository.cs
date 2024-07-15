using Dapper;
using Npgsql;
using ResumeProject.DTOs.Auth;
using ResumeProject.Repositories.Interfaces;
using ResumeProject.Exceptions;
using ResumeProject.Helper;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ResumeProject.Extentions.Interface;

namespace ResumeProject.Repositories.Implements
{
    public class AuthUserRepository:IAuthRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly ITokenHandlerBase _tokenHandler;

        public AuthUserRepository(NpgsqlConnection connection, ITokenHandlerBase tokenHandler)
        {
            _connection = connection;
            _tokenHandler = tokenHandler;
        }

        public async Task<bool> Register(RegisterDTO register)
        {
            var querySelect = "Select *from user_info where email=:userEmail or phone=:userPhone";
            var resultSelect = await _connection.QueryFirstOrDefaultAsync(querySelect, new
            {
                userEmail = register.Email,
                userPhone = register.Phone,
            });
            if (resultSelect == 1)
            {
                throw new RestException(409, "Email or phone number already exist");
            }
            var queryInsert = "Insert into user_info (first_name,last_name,email,phone,username,password,token) " +
                "Values (:name,:surname,:email,phone,:username,:passwordHash, :token)";
            if(!register.Password.Equals(register.Confirm))
            {
                throw new RestException(409,"Password and confirm don`t match");
            }
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,register.Email),
                new Claim(JwtRegisteredClaimNames.PhoneNumber,register.Phone),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var result = await _connection.ExecuteAsync(queryInsert, new
            {
                name = register.First_Name,
                surname = register.Last_Name,
                email = register.Email,
                phone = register.Phone,
                username = register.Username,
                passwordHash = PasswordHasher.HashPassword(register.Password),
                token = _tokenHandler.GenerateToken(claims)
            });
            return true;
        }

        public async Task<string> Login(LoginDTO login)
        {
            var querySelect = "Select * from user_info where email=:email or phone=:phone";
            var resultSelect = await _connection.QueryFirstOrDefaultAsync<LoginDTO>(querySelect, new { email = login.Email, phone=login.Phone});
            if(resultSelect == null)
            {
                throw new RestException(404, "User Not Found");
            }
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,login.Email),
                new Claim(JwtRegisteredClaimNames.PhoneNumber,login.Phone),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            string token = _tokenHandler.GenerateToken(claims);
            var queryUpdate = "Update user_info set token=:token";
            var resultUpdate = await _connection.ExecuteAsync(queryUpdate, new { token });
            return token;
        }

        public Task<object> ForgotPassword(ForgotPasswordDTO forgot)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ResetPassword(ResetPasswordDTO changePassword)
        {
            var querySelect = "Select password from user_info where token=:token";
            var resultSelect = await _connection.QueryFirstOrDefaultAsync<string>(querySelect, new { token = changePassword.Token });
            if (!PasswordHasher.VerifyPassword(resultSelect, PasswordHasher.HashPassword(changePassword.Old_Password)))
            {
                throw new RestException(409, "Old password is wrong");
            }

            if(!changePassword.New_Password.Equals(changePassword.Confirm_Password))
            {
                throw new RestException(409, "New Password and Confirm Password dan`t match");
            }

            var queryUpdate = "Update user_info set password=:passwordHash";
            var resultUpdate = await _connection.ExecuteAsync(queryUpdate, new 
            {
                passwordHash = PasswordHasher.HashPassword(changePassword.New_Password) 
            });
            return true;
        }
    }
}
