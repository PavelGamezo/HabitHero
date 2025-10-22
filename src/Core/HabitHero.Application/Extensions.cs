using HabitHero.Application.Common.Factories;
using HabitHero.Domain.Common.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace HabitHero.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IUserFactory, UserFactory>();

            return services;
        }
    }
}
