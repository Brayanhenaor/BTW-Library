using System;
using Domain.Common.Interfaces;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
	public static class DependencyInjection
	{
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

            services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
            return services;
        }
    }
}

