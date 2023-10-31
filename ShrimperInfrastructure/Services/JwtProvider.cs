using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShrimperCore.Domain;
using ShrimperInfrastructure.Dto;
using ShrimperInfrastructure.Extensions;
using ShrimperInfrastructure.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IOptions<JwtSettings> _settings;
        private readonly ITokenService _tokenService;

        public JwtProvider(IOptions<JwtSettings> settings,
            ITokenService tokenService)
        {
            _settings = settings;
            _tokenService = tokenService;
        }
        public JwtDto GenerateJwt(User user)
        {
            
            var now = DateTime.UtcNow;
            var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer64)
                };
            var signInCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.Key)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Value.Issuer,
                audience: _settings.Value.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),
                signInCredentials);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new JwtDto
            {
                Token = jwtToken,
            };
        }
    }
}
