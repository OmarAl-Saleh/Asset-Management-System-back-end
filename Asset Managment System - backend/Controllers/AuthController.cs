using AssetSystem.Common.Config;
using AssetSystem.Common.DTOs.Auth;
using AssetSystem.Domain.Interfaces.Services;
using FixedAssets.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AssetSystem.Common.Responses;

namespace Asset_Managment_System___backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;
        private static readonly Dictionary<string, string> _refreshTokens = new();

        public AuthController(IUserService userService, IOptions<JwtSettings> jwtOptions)
        {
            _userService = userService;
            _jwtSettings = jwtOptions.Value;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.ValidateUserAsync(dto.Username, dto.Password);
            if (user == null)
                return  Unauthorized();

            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();
            _refreshTokens[user.Username] = refreshToken;

            return WrappedOkObjectResultCls.Success(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                User = new
                {
                    user.Id,
                    user.Username,
                    user.Role,
                    user.IsActive
                }
            });
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (!_refreshTokens.TryGetValue(request.Username, out var token) || token != request.RefreshToken)
                return WrappedOkObjectResultCls.Error("Invalid refresh token");

            var user = await _userService.GetUserByUsernameAsync(request.Username);
            if (user == null)
                return WrappedOkObjectResultCls.Error("User not found");

            var newAccessToken = GenerateAccessToken(user);
            var newRefreshToken = GenerateRefreshToken();
            _refreshTokens[user.Username] = newRefreshToken;

            return WrappedOkObjectResultCls.Success(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        private string GenerateAccessToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}





