using Infrastructure.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace GrosvenorDeveloperPracticum.Configuration
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
