using HabitHero.Application.Common.Services.Authentication;
using HabitHero.Application.Common.Services.Authorization;
using HabitHero.Infrastructure.Common.Options;
using HabitHero.Infrastructure.Services.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HabitHero.Infrastructure.Services.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IUserPermissionService _userPermissionService;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions,
            IUserPermissionService userPermissionService)
        {
            _jwtOptions = jwtOptions.Value;
            _userPermissionService = userPermissionService;
        }

        public async Task<string> GenerateToken(Guid userId, string username, string email)
        {
            var permissions = await _userPermissionService.GetUserPermissionsAsync(userId);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, username),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (permissions?.Length > 0)
            {
                claims.AddRange(permissions.Select(permission => new Claim(CustomClaims.Permission, permission)));
            }

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey)),
                SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_jwtOptions.Expires),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
