namespace AeC.AutomationChallenge.WebApi
{
    public static class DependencyInjection
    {
        public static void AddWebApi(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
        }
    }
}