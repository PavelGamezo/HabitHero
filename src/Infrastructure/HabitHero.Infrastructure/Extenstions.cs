using HabitHero.Application.Common.Authentication;
using HabitHero.Application.Common.Persistence;
using HabitHero.Infrastructure.Authentication;
using HabitHero.Infrastructure.Common.Options;
using HabitHero.Infrastructure.Persistence;
using HabitHero.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HabitHero.Infrastructure
{
    public static class Extenstions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddPersistence(configuration);

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddAuthentication(configuration);

            return services;
        }

        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            configuration.Bind(JwtOptions.SectionName, jwtOptions);

            services.AddSingleton(Options.Create(jwtOptions));

            return services;
        }
    }
}
