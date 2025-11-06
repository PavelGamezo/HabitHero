using HabitHero.Application.Common.Services;
using HabitHero.Application.Common.Services.Authentication;
using HabitHero.Application.Common.Services.Authorization;
using HabitHero.Domain.Users.Enums;
using HabitHero.Infrastructure.Common.Options;
using HabitHero.Infrastructure.Persistence;
using HabitHero.Infrastructure.Services;
using HabitHero.Infrastructure.Services.Authentication;
using HabitHero.Infrastructure.Services.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HabitHero.Infrastructure
{
    public static class Extenstions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddPersistence(configuration);

            // Add Services:
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();

            services.AddJwtAuthentication(configuration);
            services.AddCustomClaimsAuthorization();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            configuration.Bind(JwtOptions.SectionName, jwtOptions);

            services.AddSingleton(Options.Create(jwtOptions));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions.SecurityKey))
                    };
                });

            services.AddAuthentication();

            return services;
        }

        public static IServiceCollection AddCustomClaimsAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                foreach (var permission in Enum.GetNames(typeof(PermissionsEnum)))
                {
                    options.AddPolicy(permission, policy =>
                        policy.RequireClaim(CustomClaims.Permission, permission));
                }
            });

            return services;
        }
    }
}
