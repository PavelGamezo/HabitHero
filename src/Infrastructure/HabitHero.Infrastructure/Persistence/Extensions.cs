﻿using HabitHero.Infrastructure.Common.Options;
using HabitHero.Infrastructure.Persistence.Contexts;
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

            services.AddSingleton(Options.Create(connectionString));

            // Add DbContext:
            services.AddDbContext<HabitHeroDbContext>(options =>
            {
                options.UseNpgsql(connectionString.Value);
            });

            return services;
        }
    }
}
