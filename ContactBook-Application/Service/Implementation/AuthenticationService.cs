﻿using AutoMapper;
using ContactBook_Application.Service.Abstraction;
using ContactBook_Domain.Dtos.Request;
using ContactBook_Domain.Enum;
using ContactBook_Domain.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Application.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private User _user;

        public AuthenticationService(ILogger<AuthenticationService> logger, IMapper mapper, UserManager<User> userManager, IConfiguration config)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
        }

        public async Task<IdentityResult> RegisterUser(UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<User>(userRequestDto);
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, userRequestDto.PassWord);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result;
        }
        public async Task<bool> ValidateUser(UserLoginDto userForAuth)
        {
            _user = await _userManager.FindByEmailAsync(userForAuth.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user,
           userForAuth.Password));
            if (!result)
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            return result;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
        List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }


    }
}
