using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResumeProject.Extentions.Interface
{
    public interface ITokenHandlerBase
    {
        string GenerateToken(List<Claim> claims);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
