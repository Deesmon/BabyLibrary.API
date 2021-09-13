using BabyLibrary.Domain.DTO;
using BabyLibrary.Options;
using BabyLibrary.Tools.DateTimeProvider;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BabyLibrary.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings, IDateTimeProvider dateTimeProvider)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string userName, string password)
        {
            //We should add some basic email validation but we will keep this simple for now

            //Check unicity
            var user = await _userManager.FindByEmailAsync(email)
                    ?? await _userManager.FindByNameAsync(userName);

            //User already exist
            if (user != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Email address already exists" }
                };
            }

            //Create user
            var newUser = new IdentityUser
            {
                Email = email,
                UserName = userName, 
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            //Failure
            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description),
                };
            }

            //Success
            var token = GenerateTokenFromIdentityUser(newUser, _jwtSettings.Secret);

            return new AuthenticationResult
            {
                Success = true,
                Token = token,
            };
        }

        public async Task<AuthenticationResult> LoginAsync(string userName, string password)
        {
            //Check unicity
            var user = await _userManager.FindByNameAsync(userName);

            //User already exist
            if (user == null)
            {
                return new AuthenticationResult
                {
                    //We don't want the user to know which one is wrong
                    Errors = new[] { "Bad login / password" }
                };
            }

            //Create user
            var authSuccess = await _userManager.CheckPasswordAsync(user, password);

            //Failure
            if (!authSuccess)
            {
                return new AuthenticationResult
                {
                    //We don't want the user to know which one is wrong
                    Errors = new[] { "Bad login / password" }
                };
            }

            //Success
            var token = GenerateTokenFromIdentityUser(user, _jwtSettings.Secret);

            return new AuthenticationResult
            {
                Success = true,
                Token = token,
            };
        }

        private string GenerateTokenFromIdentityUser(IdentityUser user, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id)
                }),
                Expires = _dateTimeProvider.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
