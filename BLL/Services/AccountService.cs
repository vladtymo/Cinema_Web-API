using Cinema.Core.DTO;
using Cinema.Core.Helpers;
using Cinema.Core.Interfaces;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOptions<JwtOptions> jwtOptions;

        public AccountService(UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            this.jwtOptions = jwtOptions;
        }

        public async Task<AuthorizationDTO> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new HttpException("Invalid login or password.", System.Net.HttpStatusCode.BadRequest);
            }

            // generate token
            return new AuthorizationDTO
            {
                Token = GenerateToken(email)
            };
        }

        public string GenerateToken(string email)
        {
            var claims  = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: jwtOptions.Value.Issuer,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(jwtOptions.Value.LifeTime),
                    signingCredentials: credentials
                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
            

        public async Task RegisterAsync(RegisterUserDTO data)
        {
            var user = new IdentityUser()
            {
                UserName = data.Email,
                Email = data.Email
            };
            var result = await _userManager.CreateAsync(user, data.Password);

            if (!result.Succeeded)
            {
                StringBuilder messageBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    messageBuilder.AppendLine(error.Description);
                }

                throw new HttpException(messageBuilder.ToString(), System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
