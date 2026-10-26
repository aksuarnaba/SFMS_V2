using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SFMS.Application.Interfaces;
using SFMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found.");

            services.AddDbContext<PalletTaggingDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IPalletTaggingDbContext>(provider => provider.GetRequiredService<PalletTaggingDbContext>());

            return services;
            
        }
    }
}
