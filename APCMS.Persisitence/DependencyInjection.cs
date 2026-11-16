using APCMS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APCMS.Persisitence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext with the connection string from configuration
            services.AddDbContext<APCMSDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("APCMSConnection")));

            // Register other persistence-related services here if needed
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(DependencyInjection))
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            return services;
        }
    }
}
