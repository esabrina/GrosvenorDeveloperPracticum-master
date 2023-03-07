using Application.Interfaces;
using Application;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public static class AppInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IDishManager, DishManager>();
            services.AddScoped<IServer, Server>();

            // Infra
            services.AddSingleton<IDishRepository, DishRepository>();

        }
    }
}
