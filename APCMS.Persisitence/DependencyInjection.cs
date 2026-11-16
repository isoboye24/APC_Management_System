using APCMS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APCMS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext with the connection string from configuration
            services.AddDbContext<APCMSDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("APCMSConnection")));

            // Automatically register persistence services
            services.Scan(scan => scan
                .FromAssemblyOf<APCMSDBContext>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            return services;
        }
    }
}
