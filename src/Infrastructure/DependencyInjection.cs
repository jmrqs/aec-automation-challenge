using AeC.AutomationChallenge.Domain.Interfaces.Repositories;
using AeC.AutomationChallenge.Infrastructure.Interfaces;
using AeC.AutomationChallenge.Infrastructure.Persistence;
using AeC.AutomationChallenge.Infrastructure.Persistence.Interceptors;
using AeC.AutomationChallenge.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AeC.AutomationChallenge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName);
                    builder.EnableRetryOnFailure();
                }));

            services.AddScoped<ApplicationDbContextInitializer>();
            services.AddScoped<EntitySaveChangesInterceptor>();
            services.AddScoped<DispatchDomainEventsInterceptor>();

            services.AddScoped<IRecordHomePageSearchDataRepository, RecordHomePageSearchDataRepository>();

            return services;
        }
    }
}