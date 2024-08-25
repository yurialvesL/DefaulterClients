using DefaulterClients.Application.DTOs.Result.User;
using DefaulterClients.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DefaulterClients.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateAccessToken(UserResponse user, IConfiguration _config)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT").GetValue<string>("SecretKey") ?? "3uf82f3iufb3i4u3b"));
            var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(UserResponse user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            
          
            return ci;
        }
    }
}
