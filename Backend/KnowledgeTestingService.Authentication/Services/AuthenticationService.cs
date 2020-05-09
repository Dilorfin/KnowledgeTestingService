using KnowledgeTestingService.Authentication.DataTransferObjects;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTestingService.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        private string JwtSecret { get; }

        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager,
            IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.JwtSecret = configuration["JWT:Secret"];
        }

        public async Task<Result<TokenDto>> LogIn(UserLogInDto userLogInDto)
        {
            var user = await userManager.FindByNameAsync(userLogInDto.UserName);
            if (user is null)
            {
                return Result.Fail<TokenDto>(-1);
            }

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, userLogInDto.Password, false);

            if (signInResult.IsLockedOut)
            {
                return Result.Fail<TokenDto>(-2);
            }

            if (!signInResult.Succeeded)
            {
                return Result.Fail<TokenDto>(-3);
            }

            var roles = await userManager.GetRolesAsync(user);

            var key = Encoding.ASCII.GetBytes(JwtSecret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Id));
            foreach (var role in roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return Result.Ok(new TokenDto
            {
                Token = tokenHandler.WriteToken(token),
                ValidTo = token.ValidTo
            });
        }

        public async Task<IEnumerable<IdentityError>> Register(UserRegisterDto userRegisterDto)
        {
            var user = new User
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email == string.Empty ? null : userRegisterDto.Email
            };

            var result = await userManager.CreateAsync(user, userRegisterDto.Password);
            if (!result.Succeeded)
            {
                return result.Errors;
            }

            result = await userManager.AddToRoleAsync(user, "user");

            if (!result.Succeeded)
            {
                return result.Errors;
            }

            return new List<IdentityError>();
        }
    }
}