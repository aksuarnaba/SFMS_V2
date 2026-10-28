using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SFMS.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(EmployeeProfile).Assembly);

            return services;
        }
    }
}
