using AeC.AutomationChallenge.Application.Common.Behaviours;
using Microsoft.Extensions.DependencyInjection;

namespace AeC.AutomationChallenge.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(DependencyInjection).Assembly;

            services.AddValidatorsFromAssembly(applicationAssembly);

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(applicationAssembly);
                config.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
                config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                config.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
            });

            return services;
        }
    }
}