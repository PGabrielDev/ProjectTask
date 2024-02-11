using Microsoft.IdentityModel.Tokens;
using ProjectsTasks.Infrastruct.Database.entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectsTasks.utils
{
    public class JWTUtils
    {
        private readonly IConfiguration _configuration;

        public JWTUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(EmailRole user)
        {
            var handler = new JwtSecurityTokenHandler();


            var tokenKey = Encoding.UTF8.GetBytes(_configuration["TokenSettings:TokenSecret"]);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["TokenSettings:Audience"],
                Issuer = _configuration["TokenSettings:Issuer"],
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };

            var token = handler.CreateToken(tokenDescriptor);

            var tokenStr = handler.WriteToken(token);
            return tokenStr;
        }

        public static ClaimsIdentity GenerateClaims(EmailRole user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            if (user.Roles != null)
                foreach (var item in user.Roles)
                    claims.AddClaim(new Claim(ClaimTypes.Role, item));
            return claims;
        }
    }
}
