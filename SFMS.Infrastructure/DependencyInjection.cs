using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SFMS.Application.Common.Interfaces;
using SFMS.Infrastructure.Data;
using SFMS.Infrastructure.Repositories;
using SFMS.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found.");

            services.AddDbContext<PalletTaggingDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
            
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
