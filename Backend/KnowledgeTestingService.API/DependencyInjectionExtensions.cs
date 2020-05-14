using KnowledgeTestingService.API.Services.Authentication;
using KnowledgeTestingService.API.Services.Tests;
using KnowledgeTestingService.Authentication;
using KnowledgeTestingService.Authentication.Services;
using KnowledgeTestingService.BLL.TestResults.Services;
using KnowledgeTestingService.BLL.Tests.Services;
using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace KnowledgeTestingService.API
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection ResolveDalDependencies(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection ResolveServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationResponseComposer, AuthenticationResponseComposer>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITestResultService, TestResultService>();

            services.AddScoped<ITestResultResponseComposer, TestResultResponseComposer>();
            services.AddScoped<ITestQueryingResponseComposer, TestQueryingResponseComposer>();
            services.AddScoped<ITestManagementResponseComposer, TestManagementResponseComposer>();

            return services;
        }

        public static IServiceCollection ResolveIdentityDependencies(this IServiceCollection services,
            string connectionString, string jwtSigningKey, string jwtEncryptionKey)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Lockout.AllowedForNewUsers = true;
                })
                .AddEntityFrameworkStores<IdentityContext>();

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSigningKey));

            SymmetricSecurityKey decryptionKey;
            using (var sha256 = SHA256.Create())
            {
                var computeHash = sha256.ComputeHash(Encoding.Default.GetBytes(jwtEncryptionKey));
                decryptionKey = new SymmetricSecurityKey(computeHash);
            }
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        TokenDecryptionKey = decryptionKey,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });

            return services;
        }
    }
}