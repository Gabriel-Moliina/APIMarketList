using APIMarketList.Domain.DTO.Authentication;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Infra.Authentication.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIMarketList.Infra.Authentication.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        public TokenService(IOptions<JwtSettings> jwtSettings, IConfiguration configuration)
        {
            _jwtSettings = new JwtSettings{
                SecretKey = configuration.GetSection("JwtSettings:Secret").Value,
                ExpirationInMinutes = int.Parse(configuration.GetSection("JwtSettings:ExpirationInMinutes").Value)
            };
        }
        public string GenerateToken(UserDTO user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrEmpty(_jwtSettings?.SecretKey)) 
                throw new ArgumentNullException("Token secret não configurado");

            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetSecret()
        {
            return _jwtSettings.SecretKey;
        }
    }
}
