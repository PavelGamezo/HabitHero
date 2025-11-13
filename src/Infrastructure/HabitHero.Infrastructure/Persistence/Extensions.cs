using HabitHero.Application.Common.Persistence;
using HabitHero.Infrastructure.Common.Options;
using HabitHero.Infrastructure.Persistence.Contexts;
using HabitHero.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HabitHero.Infrastructure.Persistence
{
    public static class Extensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = new ConnectionString();
            configuration.Bind(ConnectionString.SectionName, connectionString);

            // Add Options:
            services.AddSingleton(Options.Create(connectionString));
            services.Configure<AuthorizationOptions>(configuration.GetSection(AuthorizationOptions.SectionName));

            // Add DbContext:
            services.AddDbContext<HabitHeroDbContext>(options =>
            {
                options.UseNpgsql(connectionString.Value);
            });

            // Add Repositories:
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IHabitRepository, HabitRepository>();

            return services;
        }
    }
}
