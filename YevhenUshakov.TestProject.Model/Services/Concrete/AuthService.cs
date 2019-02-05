using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Data.Repositories.Abstract;
using YevhenUshakov.TestProject.Model.Auth;
using YevhenUshakov.TestProject.Model.Exceptions;
using YevhenUshakov.TestProject.Model.Services.Abstract;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace YevhenUshakov.TestProject.Model.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISettingsService _settingsService;

        public AuthService(IUserRepository userRepository, ISettingsService settingsService)
        {
            _userRepository = userRepository;
            _settingsService = settingsService;
        }

        public TokenModel Login(LoginModel model)
        {
            var user = _userRepository.Get(model.Login, model.Password);
            if (user == null)
            {
                throw new BusinessException(-2, "Invalid User or Password");
            }

            return GenerateToken(user);
        }

        private TokenModel GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settingsService.JwtSettings.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(_settingsService.JwtSettings.ExpireDays);

            var jwtToken = new JwtSecurityToken(
                _settingsService.JwtSettings.Issuer,
                null,
                claims,
                expires: expires,
                signingCredentials: signingCredentials
            );

            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                ExpiresIn = DateTime.UtcNow.AddDays(_settingsService.JwtSettings.ExpireDays)
            };
        }
    }
}
