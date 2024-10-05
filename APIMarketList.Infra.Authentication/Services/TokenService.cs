using APIMarketList.Domain.DTO.Authentication;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Infra.Authentication.Interface;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenService(IOptions<JwtSettings> jwtSettings, 
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public UserDTO GetUser()
        {
            var user = _httpContextAccessor.HttpContext.User;

            return new UserDTO
            {
                Id = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value),
                Name = user.FindFirst(ClaimTypes.Name)?.Value,
                Email = user.FindFirst(ClaimTypes.Email)?.Value
            };
        }

        public string GetSecret()
        {
            return _jwtSettings.SecretKey;
        }
    }
}
