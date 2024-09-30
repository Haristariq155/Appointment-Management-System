using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppointmentManagementUserApi.Helpers
{
    public class JWTAuth
    {

        private readonly IConfiguration _configuration;

        public JWTAuth(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(int userId, string userName)
        {
            // Get JWT settings from configuration
            var jwtSettings = _configuration.GetSection("Jwt");

            // Define claims (you can add more claims as needed)
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()), // Replace with actual user ID or username
            new Claim(JwtRegisteredClaimNames.Name, userName), // Replace with actual user ID or username
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // Secret key to sign the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the JWT token
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),  // Token expiration time
                signingCredentials: credentials
            );

            // Write the token and return
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
