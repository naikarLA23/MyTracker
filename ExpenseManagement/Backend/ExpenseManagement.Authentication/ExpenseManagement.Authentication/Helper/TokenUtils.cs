using ExpenseManagement.Authentication.Helper.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseManagement.Authentication.Helper
{
    public class TokenUtils
    {
        public static string GenerateAccessToken(IConfiguration config, string userName, string role)
        {
            var authClaims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, userName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authClaims.AddRange([new(ClaimTypes.Role, role)]);

            var tokenOptions = new JwtSecurityToken(
                issuer: config[AppSettingKeys.JWT_ISSUER],
                expires: DateTime.Now.AddMinutes(double.Parse(config[AppSettingKeys.JWT_EXPIRY_MINUTES]!)),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config[AppSettingKeys.JWT_Key]!)), SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public static string GenerateAccessTokenFromRefreshToken(IConfiguration config, string userName, string role)
        {
            //// Implement logic to generate a new access token from the refresh token
            //// Verify the refresh token and extract necessary information (e.g., user ID)

            //var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //var newSecurityKey = Encoding.ASCII.GetBytes(config["Jwt:Key"]!);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Expires = DateTime.UtcNow.AddMinutes(double.Parse(config["Jwt:ExpiryMinutes"]!)), 
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(newSecurityKey), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var securityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            //return jwtSecurityTokenHandler.WriteToken(securityToken);

            return GenerateAccessToken(config, userName, role);
        }
    }
}
