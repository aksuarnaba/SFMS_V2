using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SFMS.Application.Common.Interfaces.Persistence;
using SFMS.Application.Common.Interfaces.Security;
using SFMS.Infrastructure.Persistence.Context;
using SFMS.Infrastructure.Persistence.Repositories;
using SFMS.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SFMSConnection")
                ?? throw new InvalidOperationException("Connection string 'SFMS Connection' was not found.");

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddScoped<ITokenService, JwtTokenService>();

            services.AddDbContext<SFMSDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, JwtTokenService>();

            return services;
        }
    }
}
