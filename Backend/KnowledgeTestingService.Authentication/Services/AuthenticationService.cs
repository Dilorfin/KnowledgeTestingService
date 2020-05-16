using KnowledgeTestingService.Authentication.DataTransferObjects;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTestingService.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ILogger<AuthenticationService> logger;

        private string JwtSigningKey { get; }
        private string JwtEncryptionKey { get; }

        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager,
            IConfiguration configuration, ILogger<AuthenticationService> logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
            this.JwtSigningKey = configuration["JWT:SigningKey"];
            this.JwtEncryptionKey = configuration["JWT:EncryptionKey"];
        }

        public async Task<Result<TokenDto>> LogIn(UserLogInDto userLogInDto)
        {
            var user = await userManager.FindByNameAsync(userLogInDto.UserName);
            if (user is null)
            {
                logger.LogInformation($"Unknown username: {userLogInDto.UserName}");
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
            

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSigningKey));
            SymmetricSecurityKey encryptionKey;
            using (var sha256 = SHA256.Create())
            {
                var computeHash = sha256.ComputeHash(Encoding.Default.GetBytes(JwtEncryptionKey));
                encryptionKey = new SymmetricSecurityKey(computeHash);
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Id));
            foreach (var role in roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var encryptingCredentials = new EncryptingCredentials(encryptionKey, SecurityAlgorithms.Aes256KW,
                SecurityAlgorithms.Aes256CbcHmacSha512);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials
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
            logger.LogInformation($"New user registered: {user.UserName}");
            return new List<IdentityError>();
        }
    }
}