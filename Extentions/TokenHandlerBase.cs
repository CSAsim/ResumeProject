using Microsoft.IdentityModel.Tokens;
using ResumeProject.Extentions.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResumeProject.Extentions
{
    public class TokenHandlerBase:ITokenHandlerBase
    {
        private readonly IConfiguration _configuration;
        public TokenHandlerBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(List<Claim> claims)
        {
            string secret = _configuration.GetSection("JWT:Secret").Value!;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken securityToken = new(
                issuer: _configuration.GetSection("JWT:Issuer").Value,
                audience: _configuration.GetSection("JWT:Audience").Value,
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddDays(1)
            );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            string secret = _configuration.GetSection("JWT:Secret").Value!;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));


            // JwtSecurityTokenHandler instansiyası yaradılır.
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principialToken = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true, // Verənin doğrulanmasını tələb edirik.
                    ValidateAudience = true, // Dinləyicinin doğrulanmasını tələb edirik.
                    ValidateLifetime = true, // Tokenin müddətinin doğrulanmasını tələb edirik.
                    ValidateIssuerSigningKey = true, // İmzalayıcı açarın doğrulanmasını tələb edirik.
                    ValidIssuer = _configuration.GetSection("JWT:Issues").Value, // Doğru verəni təyin edirik.
                    ValidAudience = _configuration.GetSection("JWT:Audience").Value, // Doğru dinləyicini təyin edirik.
                    IssuerSigningKey = key // İmzalayıcı açarı təyin edirik.
                }, out SecurityToken validateROken);
                return principialToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token is invalid {ex.Message}");
                return null;
            }
        }
    }
}
