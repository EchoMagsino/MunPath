using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MunPath.Application.Abstraction;
using MunPath.Application.Service;
using MunPath.Domain.Abstraction;
using MunPath.Domain.Entities;
using MunPath.Infrastructure.Repositories;

namespace MunPath.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext with Pomelo MySQL provider
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    config.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection"))
                ));

            // Register repositories and services
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IPasswordHasher<Student>, PasswordHasher<Student>>();


            return services;
        }
    }
}
