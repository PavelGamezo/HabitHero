using HabitHero.Application.Common.Factories;
using HabitHero.Domain.Common.Factory;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HabitHero.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
