using eCommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Infrastructure.Dependency_injection
{

    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService
            (this IServiceCollection services, IConfiguration config)
        {
            string connectionString = "Default";
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString(connectionString),
                        sqlOptions =>
                        {
                            // Ensure this is the correct assembly
                            sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                            sqlOptions.EnableRetryOnFailure(); //Enable automatic retries for transient failures
                        }),
                ServiceLifetime.Scoped);
            return services;
        }
    }
}


