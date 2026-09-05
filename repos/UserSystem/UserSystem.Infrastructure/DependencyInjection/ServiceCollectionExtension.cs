using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UserSystem.Domain.Interface;
using UserSystem.Infrastructure.Repository;
using UserSystem.Infrastructure.Data;

namespace UserSystem.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
      
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Register ApplicationDbContext with Pomelo MySQL provider
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    config.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection"))
                ));

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
      
    }
}