using Infrastructure.IoC;

namespace API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            AppInjector.RegisterServices(services);
        }
    }
}
