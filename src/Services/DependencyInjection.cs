using AeC.AutomationChallenge.Domain.Interfaces.Services;
using AeC.AutomationChallenge.Services.Services.GetHomePageSearchData;
using Microsoft.Extensions.DependencyInjection;

namespace AeC.AutomationChallenge.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGetHomePageSearchDataService, GetHomePageSearchDataService>();

            return services;
        }
    }
}