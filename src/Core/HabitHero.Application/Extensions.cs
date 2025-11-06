using FluentValidation;
using HabitHero.Application.Common.Behaviors;
using HabitHero.Application.Common.Factories;
using HabitHero.Domain.Common.Factory;
using MediatR;
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

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(LogginBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
